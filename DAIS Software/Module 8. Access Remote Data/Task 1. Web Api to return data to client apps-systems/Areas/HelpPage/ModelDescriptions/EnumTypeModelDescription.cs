using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Task_1.Web_Api_to_return_data_to_client_apps_systems.Areas.HelpPage.ModelDescriptions
{
    public class EnumTypeModelDescription : ModelDescription
    {
        public EnumTypeModelDescription()
        {
            Values = new Collection<EnumValueDescription>();
        }

        public Collection<EnumValueDescription> Values { get; private set; }
    }
}