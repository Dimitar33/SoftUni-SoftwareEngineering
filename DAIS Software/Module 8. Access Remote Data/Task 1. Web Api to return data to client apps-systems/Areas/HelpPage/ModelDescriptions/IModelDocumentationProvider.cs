using System;
using System.Reflection;

namespace Task_1.Web_Api_to_return_data_to_client_apps_systems.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}