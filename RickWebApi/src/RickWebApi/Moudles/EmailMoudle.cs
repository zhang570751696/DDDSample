using Autofac;
using RickWebApi.Infrastructure.Emails;

namespace RickWebApi.Moudles
{
    public class EmailMoudle : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EmailSender>()
                .As<IEmailSender>()
                .InstancePerLifetimeScope();
        }
    }
}
