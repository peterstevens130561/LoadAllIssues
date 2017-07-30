using PeterSoft.SonarQube.Connector.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeterSoft.SonarQube.Connector.Models;
using PeterSoft.SonarQube.Connector.Client;
using PeterSoft.SonarQube.Connector.API.Logic;

namespace PeterSoft.SonarQube.Connector.Commands
{
    class PermissionsDeleteTemplateCommand : ParametersBase, IPermissionsDeleteTemplateCommand
    {
        public PermissionsDeleteTemplateCommand(IRestParameters restParameters) : base(restParameters)
        {
        }


        public IPermissionsDeleteTemplateCommand SetTemplateId(string templateId) {
                SetParameter("templateId", templateId);
            return this;
            }

        public IPermissionsDeleteTemplateCommand SetTemplateName(string templateName) {
                SetParameter("templateName", templateName);
            return this;
            }


    }
}
