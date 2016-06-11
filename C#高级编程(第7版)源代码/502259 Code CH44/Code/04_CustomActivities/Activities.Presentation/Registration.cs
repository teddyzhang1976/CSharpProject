using System;
using System.Activities.Presentation.Metadata;

namespace Activities.Presentation
{
    public class Registration : IRegisterMetadata
    {
        public void Register()
        {
            AttributeTableBuilder atb = new AttributeTableBuilder();

            DebugWriteDesigner.RegisterMetadata(atb);
        }
    }
}
