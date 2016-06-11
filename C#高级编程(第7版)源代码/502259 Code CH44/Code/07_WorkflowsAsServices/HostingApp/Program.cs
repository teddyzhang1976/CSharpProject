using System;
using System.ServiceModel.Activities;
using System.Xml.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Activities.Statements;
using System.Activities;
using System.Collections.Generic;
using System.ServiceModel.Dispatcher;
using System.Activities.Expressions;
using System.Drawing;

namespace HostingApp
{
    class Program
    {
        static string ns = "http://pro-csharp/";

        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:8080/PropertyService";

            using (WorkflowServiceHost host = new WorkflowServiceHost(GetPropertyWorkflow(), new Uri(baseAddress)))
            {
                host.UnknownMessageReceived += new EventHandler<UnknownMessageReceivedEventArgs>(OnUnknownMessage);
                host.AddServiceEndpoint(XName.Get("IProperty", ns), new BasicHttpBinding(), baseAddress);

                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                host.Description.Behaviors.Add(smb);

                try
                {
                    host.Open();

                    Console.WriteLine("Service host is open for business. Press [Enter] to close the host...");
                    Console.ReadLine();
                }
                finally
                {
                    host.Close();
                }
            }
        }

        static void OnUnknownMessage(object sender, UnknownMessageReceivedEventArgs e)
        {
            Console.WriteLine("Received an unexpected message");
            Console.WriteLine(e.Message.ToString());
        }

        private static Activity GetPropertyWorkflow()
        {
            // Correlation handle used to link operations together
            Variable<CorrelationHandle> operationHandle = new Variable<CorrelationHandle>();

            // The generated property Id
            Variable<Guid> propertyId = new Variable<Guid>();

            // Variable used to indicate that the workflow should finish
            Variable<bool> finished = new Variable<bool>("Finished", false);

            Variable<string> address = new Variable<string>();
            Variable<string> owner = new Variable<string>();
            Variable<double> askingPrice = new Variable<double>();

            // Initial receive - this kicks off the workflow
            Receive receive = new Receive
            {
                CanCreateInstance = true,
                OperationName = "UploadPropertyInformation",
                ServiceContractName = XName.Get("IProperty", ns),
                Content = new ReceiveParametersContent
                {
                    Parameters =
                    {
                        {"address", new OutArgument<string>(address)},
                        {"owner", new OutArgument<string>(owner)},
                        {"askingPrice", new OutArgument<double>(askingPrice)}
                    }
                }
            };

            // Define the local namespace
            XPathMessageContext messageContext = new XPathMessageContext();
            messageContext.AddNamespace("local", ns);

            // Extracts the guid sent back to the client on the initial response
            MessageQuerySet extractGuid = new MessageQuerySet
            {
                { "PropertyId", new XPathMessageQuery ( "sm:body()/ser:guid", messageContext ) }
            };

            // Extracts the guid sent up with the property image
            MessageQuerySet extractGuidFromUploadRoomInformation = new MessageQuerySet
            {
                { "PropertyId", new XPathMessageQuery ( @"sm:body()/local:UploadRoomInformation/local:propertyId", messageContext ) }
            };

            // Receive used to indicate that the upload is complete
            Receive receiveDetailsComplete = new Receive
            {
                OperationName = "DetailsComplete", 
                ServiceContractName = XName.Get("IProperty", ns),
                CorrelatesWith = operationHandle,
                CorrelatesOn = extractGuid,
                Content = ReceiveContent.Create(new OutArgument<Guid>(propertyId))
            };

            Variable<string> roomName = new Variable<string>();
            Variable<double> width = new Variable<double>();
            Variable<double> depth = new Variable<double>();

            // Receive room information
            Receive receiveRoomInfo = new Receive
            {
                OperationName = "UploadRoomInformation",
                ServiceContractName = XName.Get("IProperty", ns),
                CorrelatesWith = operationHandle,
                CorrelatesOn = extractGuidFromUploadRoomInformation,
                Content = new ReceiveParametersContent
                {
                    Parameters =
                    {
                        {"propertyId", new OutArgument<Guid>()},
                        {"roomName", new OutArgument<string>(roomName)},
                        {"width", new OutArgument<double>(width)},
                        {"depth", new OutArgument<double>(depth)},
                    }
                }
            };

            return new Sequence
            {
                Variables = { propertyId, operationHandle, finished, address, owner, askingPrice },
                Activities =
                {
                    receive,
                    new WriteLine { Text = "Assigning a unique ID" },
                    new Assign<Guid>
                    {
                        To = new OutArgument<Guid> (propertyId),
                        Value = new InArgument<Guid> (Guid.NewGuid())
                    },
                    new WriteLine  { Text = new InArgument<string> (env => string.Format ("{0} is selling {1} for {2}.\r\nAssigned unique id {3}.", owner.Get(env), address.Get(env), askingPrice.Get(env), propertyId.Get(env)))},
                    new SendReply
                    {
                        Request = receive,
                        Content = SendContent.Create (new InArgument<Guid> (env => propertyId.Get(env))),
                        CorrelationInitializers = 
                        {
                            new QueryCorrelationInitializer
                            {
                                CorrelationHandle = operationHandle,
                                MessageQuerySet = extractGuid
                            }
                        }
                    },
                    new While
                    {
                        Condition = ExpressionServices.Convert<bool>(env => !finished.Get(env)),
                        Body = new Pick
                        {
                            Branches = 
                            {
                                new PickBranch
                                {
                                    Variables = { roomName, width, depth },
                                    Trigger = receiveRoomInfo,
                                    Action = new WriteLine { Text = new InArgument<string> (env => string.Format ("Room '{0}' uploaded, dimensions {1}W x {2}D", roomName.Get(env), width.Get(env), depth.Get(env)))},
                                },
                                new PickBranch
                                {
                                    Trigger = receiveDetailsComplete,
                                    Action = new Sequence
                                    {
                                        Activities = 
                                        {
                                            new Assign<bool> 
                                            {
                                                To = new OutArgument<bool>(finished),
                                                Value = new InArgument<bool>(true)
                                            },
                                            new WriteLine { Text = "Property Details Complete" }
                                        }
                                    }
                                }
                            }
                        }
                    },
                    new WriteLine { Text = "Finished!" }
                }
            };
        }
    }
}
