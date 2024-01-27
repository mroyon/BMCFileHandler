﻿using Autofac;
using Web.Core.Frame.Presenters;

namespace Web.Core.Frame
{
    public partial class CorePresenter : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Auth_Presenter>().InstancePerLifetimeScope();

            builder.RegisterType<HomePresenter>().InstancePerLifetimeScope();



            builder.RegisterType<Owin_FormActionPresenter>().InstancePerLifetimeScope();
            builder.RegisterType<Owin_LastWorkingPagePresenter>().InstancePerLifetimeScope();
            builder.RegisterType<Owin_RolePermissionPresenter>().InstancePerLifetimeScope();
            builder.RegisterType<Owin_RolePresenter>().InstancePerLifetimeScope();
            builder.RegisterType<Owin_UserClaimsPresenter>().InstancePerLifetimeScope();
            builder.RegisterType<Owin_UserLoginTrailPresenter>().InstancePerLifetimeScope();
            builder.RegisterType<Owin_UserPasswordResetInfoPresenter>().InstancePerLifetimeScope();

            builder.RegisterType<Owin_UserPrefferencesSettingsPresenter>().InstancePerLifetimeScope();
            builder.RegisterType<Owin_UserPresenter>().InstancePerLifetimeScope();
            builder.RegisterType<Owin_UserRolePresenter>().InstancePerLifetimeScope();
            builder.RegisterType<Owin_UserRolesPresenter>().InstancePerLifetimeScope();
            builder.RegisterType<Owin_UserStatusChangeHistoryPresenter>().InstancePerLifetimeScope();
            builder.RegisterType<ExchangeRefreshTokenPresenter>().InstancePerLifetimeScope();
            builder.RegisterType<LoginPresenter>().InstancePerLifetimeScope();
            builder.RegisterType<RegisterUserPresenter>().InstancePerLifetimeScope();



            builder.RegisterType<FileStructurePresenter>().InstancePerLifetimeScope();
            builder.RegisterType<FIleUserRelationPresenter>().InstancePerLifetimeScope();
            builder.RegisterType<FolderStructurePresenter>().InstancePerLifetimeScope();
            builder.RegisterType<FolderUserRelationPresenter>().InstancePerLifetimeScope();

            builder.RegisterType<Gen_ServiceInfoPresenter>().InstancePerLifetimeScope();
        }
    }
}
