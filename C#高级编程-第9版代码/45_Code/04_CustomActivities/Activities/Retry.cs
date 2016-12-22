using System;
using System.Activities;
using System.Activities.Expressions;
using System.Activities.Statements;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activities
{
    [Designer("Activities.Design.RetryDesigner, Activities.Design")]
    public class Retry : Activity
    {
        public Activity Body { get; set; }

        [RequiredArgument]
        public InArgument<int> NumberOfRetries { get; set; }

        public Retry()
        {
            Variable<int> iterationCount = new Variable<int>("iterationCount", 0);
            Variable<bool> looping = new Variable<bool>("looping", true);

            this.Implementation = () =>
            {
                return new While
                {
                    Variables = { iterationCount, looping },
                    Condition = new VariableValue<bool> { Variable = looping },
                    Body = new TryCatch
                    {
                        Try = new Sequence
                        {
                            Activities = 
                            {
                                this.Body,
                                new Assign
                                {
                                    To = new OutArgument<bool> ( looping ), 
                                    Value = new InArgument<bool> { Expression = false }
                                }
                            }
                        },
                        Catches =
                        {
                            new Catch<Exception>
                            {
                                Action = new ActivityAction<Exception>
                                {
                                    Handler = new Sequence
                                    {
                                        Activities = 
                                        {
                                            new Assign
                                            {
                                                To = new OutArgument<int> ( iterationCount ) ,
                                                Value = new InArgument<int> ( ctx => iterationCount.Get(ctx) + 1 )
                                            },
                                            new If
                                            {
                                                Condition = new InArgument<bool>(env=>iterationCount.Get(env) >= NumberOfRetries.Get(env)),
                                                Then = new Rethrow()
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                };
            };
        }
    }
}
