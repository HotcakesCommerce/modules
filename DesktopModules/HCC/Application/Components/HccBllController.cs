#region License

// Distributed under the MIT License
// ============================================================
// Copyright (c) 2017-2018 Hotcakes Commerce, LLC
// Copyright (c) 2019-2020 Upendo Ventures, LLC
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software 
// and associated documentation files (the "Software"), to deal in the Software without restriction, 
// including without limitation the rights to use, copy, modify, merge, publish, distribute, 
// sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is 
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or 
// substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR 
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE 
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN 
// THE SOFTWARE.

#endregion

using System;
using DotNetNuke.Entities.Controllers;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Entities.Tabs;
using DotNetNuke.Instrumentation;
using DotNetNuke.Modules.Html;
using DotNetNuke.Services.Exceptions;

namespace HCC.Application
{
    public class HccBllController : IUpgradeable
    {
        private static readonly ILog Logger = LoggerSource.Instance.GetLogger(typeof(HccBllController));
        public string UpgradeModule(string Version)
        {
            try
            {
                switch (Version)
                {
                    case "03.03.00":
                        UpdateCmsModules();
                        break;

                    default:
                        break;
                }

                return "Success";
            }
            catch (Exception ex)
            {
                LogError(ex.Message, ex);
                Exceptions.LogException(ex);

                return "Failed";
            }
        }

        private void UpdateCmsModules()
        {
            var runDate = HostController.Instance.GetString("HccApp.UpdateHccCmsModules", string.Empty);

            if (string.IsNullOrEmpty(runDate)) return;

            var portals = PortalController.Instance.GetPortals();

            foreach (PortalInfo portal in portals)
            {
                var homeTab = TabController.Instance.GetTab(portal.HomeTabId, portal.PortalID);
                var modules = homeTab.Modules;

                foreach (ModuleInfo module in modules)
                {
                    try
                    {
                        if (module.ModuleTitle == "Hotcakes Commerce Welcome Header")
                        {
                            UpdateHtmlModuleContent(module.ModuleID, homeTab.TabID, portal.PortalID,
                                "&lt;h1 class=&quot;text-center&quot; style=&quot; margin-top: 1em;&quot;&gt;Hotcakes Commerce CMS&lt;/h1&gt; &lt;h2 class=&quot;text-center&quot;&gt;[Tab.Home.Header.NextSteps]&lt;/h2&gt;");
                        }

                        if (module.ModuleTitle == "Hotcakes Commerce: Step 1")
                        {

                            UpdateHtmlModuleContent(module.ModuleID, homeTab.TabID, portal.PortalID,
                                "&lt;div class=&quot;gray-container&quot;&gt;&lt;a href=&quot;/DesktopModules/Hotcakes/Core/Admin/SetupWizard/SetupWizard.aspx?step=0&quot;&gt;&lt;img alt=&quot;wizard icon&quot; class=&quot;icon&quot; src=&quot;/portals/0/Images/wizard-icon.png&quot; /&gt;&lt;/a&gt; &lt;h2&gt;[Tab.Home.Step1.Header]&lt;/h2&gt; &lt;h3&gt;&lt;a href=&quot;/DesktopModules/Hotcakes/Core/Admin/SetupWizard/SetupWizard.aspx?step=0&quot;&gt;Hotcakes Wizard&lt;/a&gt;&lt;/h3&gt; &lt;p&gt;[Tab.Home.Step1.Description]&lt;/p&gt; &lt;a href=&quot;/DesktopModules/Hotcakes/Core/Admin/SetupWizard/SetupWizard.aspx?step=0&quot;&gt;&lt;img alt=&quot;wizard sample&quot; class=&quot;sample&quot; src=&quot;/portals/0/Images/wizard-sample.png&quot; /&gt;&lt;/a&gt;&lt;/div&gt;");
                        }

                        if (module.ModuleTitle == "Hotcakes Commerce: Step 2")
                        {
                            UpdateHtmlModuleContent(module.ModuleID, homeTab.TabID, portal.PortalID,
                                "&lt;div class=&quot;darkgray-container&quot;&gt;&lt;a href=&quot;/DesktopModules/Hotcakes/Core/Admin/catalog/default.aspx&quot;&gt;&lt;img alt=&quot;products icon&quot; class=&quot;icon&quot; src=&quot;/portals/0/Images/products-icon.png&quot; /&gt;&lt;/a&gt;&lt;h2&gt;[Tab.Home.Step2.Header]&lt;/h2&gt;&lt;h3&gt;&lt;a href=&quot;/DesktopModules/Hotcakes/Core/Admin/catalog/default.aspx&quot;&gt;Sample Products&lt;/a&gt;&lt;/h3&gt;&lt;p&gt;[Tab.Home.Step2.Description]&lt;/p&gt;&lt;a href=&quot;/DesktopModules/Hotcakes/Core/Admin/catalog/default.aspx&quot;&gt;&lt;img alt=&quot;products sample&quot; class=&quot;sample&quot; src=&quot;/portals/0/Images/products-sample.png&quot; /&gt;&lt;/a&gt;&lt;/div&gt;");
                        }

                        if (module.ModuleTitle == "Hotcakes Commerce: Step 3")
                        {
                            UpdateHtmlModuleContent(module.ModuleID, homeTab.TabID, portal.PortalID,
                                "&lt;div class=&quot;blue-container&quot;&gt;&lt;img src=&quot;/portals/0/Images/enjoy-icon.png&quot; class=&quot;icon&quot; alt=&quot;products icon&quot; /&gt;&lt;h2&gt;Step 3&lt;/h2&gt;&lt;h3&gt;[Tab.Home.StepEnjoy.Header]&lt;/h3&gt;&lt;img src=&quot;/portals/0/Images/store.png&quot; class=&quot;sample&quot; alt=&quot;Hotcakes Commerce CMS&quot; /&gt;&lt;/div&gt;");
                        }

                        if (module.ModuleTitle == "Hotcakes Cloud by Upendo Ventures")
                        {
                            UpdateHtmlModuleContent(module.ModuleID, homeTab.TabID, portal.PortalID,
                                "&lt;div class=&quot;orange-container&quot;&gt;&lt;div class=&quot;container&quot;&gt;&lt;div class=&quot;row-fluid&quot;&gt;&lt;div class=&quot;span6&quot;&gt;&lt;img alt=&quot;Hotcakes Commerce&quot; class=&quot;icon&quot; src=&quot;/portals/0/Images/hc-logo-white.png&quot; /&gt;&lt;h2&gt;[Tab.Home.HccCloud.Header]&lt;/h2&gt;&lt;a class=&quot;btn&quot; href=&quot;https://upendoventures.com/Shop/Product/Hotcakes-Commerce-Cloud?utm_source=hcc&amp;utm_medium=cms&amp;utm_campaign=330&quot; target=&quot;_blank&quot;&gt;Hotcakes Cloud&lt;/a&gt;&lt;/div&gt;&lt;div class=&quot;span6&quot;&gt;&lt;img alt=&quot;Hotcakes Commerce&quot; class=&quot;sample&quot; src=&quot;/portals/0/Images/mac-laptop.png&quot; /&gt;&lt;/div&gt;&lt;/div&gt;&lt;/div&gt;&lt;/div&gt;");
                        }

                        if (module.ModuleTitle == "Hotcakes Commerce: See How")
                        {
                            UpdateHtmlModuleContent(module.ModuleID, homeTab.TabID, portal.PortalID,
                                "&lt;div class=&quot;gray-container2&quot;&gt;&lt;div class=&quot;container&quot;&gt;&lt;div class=&quot;row-fluid&quot;&gt;&lt;div class=&quot;span7&quot;&gt;&lt;p&gt;[Tab.Home.SeeHow.Description]&lt;/p&gt;&lt;/div&gt;&lt;div class=&quot;span5&quot;&gt;&lt;a class=&quot;btn&quot; href=&quot;https://hotcakes.org/Product?utm_source=hcc&amp;utm_medium=cms&amp;utm_campaign=330&quot; target=&quot;_blank&quot;&gt;[Tab.Home.SeeHow.Link.Text]&lt;/a&gt;&lt;/div&gt;&lt;/div&gt;&lt;/div&gt;&lt;/div&gt;");
                        }

                        if (module.ModuleTitle == "Hotcakes Commerce: Get Help")
                        {
                            UpdateHtmlModuleContent(module.ModuleID, homeTab.TabID, portal.PortalID,
                                "&lt;div class=&quot;row-fluid question-container&quot;&gt;&lt;div class=&quot;span3&quot;&gt;&lt;a href=&quot;https://hotcakes.org/Community?utm_source=hcc&amp;utm_medium=cms&amp;utm_campaign=330&quot; target=&quot;_blank&quot;&gt;&lt;img alt=&quot;&quot; class=&quot;icon&quot; src=&quot;/portals/0/Images/question-icon.png&quot; /&gt;&lt;/a&gt;&lt;/div&gt;&lt;div class=&quot;span9&quot;&gt;&lt;h2&gt;[Tab.Home.GetHelp.Header]&lt;/h2&gt;&lt;p&gt;[Tab.Home.GetHelp.Para1]&lt;/p&gt;&lt;p&gt;[Tab.Home.GetHelp.Para2]&lt;/p&gt;&lt;a class=&quot;btn&quot; href=&quot;https://upendoventures.com/Support?utm_source=hcc&amp;utm_medium=cms&amp;utm_campaign=330&quot; target=&quot;_blank&quot;&gt;[Tab.Home.GetHelp.Link.Text]&lt;/a&gt;&lt;/div&gt;&lt;/div&gt;");
                        }
                    }
                    catch (Exception e)
                    {
                        LogError(e.Message, e);
                    }
                }
            }

            HostController.Instance.Update("HccApp.UpdateHccCmsModules", DateTime.Now.Date.ToString());
        }

        private bool UpdateHtmlModuleContent(int moduleId, int tabId, int portalId, string content)
        {
            try
            {
                var ctlHtml = new HtmlTextController();
                var workflowID = ctlHtml.GetWorkflow(moduleId, tabId, portalId).Value;
                var maxHistory = ctlHtml.GetMaximumVersionHistory(portalId);

                var htmlContent = ctlHtml.GetTopHtmlText(moduleId, false, workflowID);

                if (htmlContent == null)
                {
                    htmlContent = new HtmlTextInfo
                    {
                        ItemID = -1,
                        WorkflowID = workflowID,
                        ModuleID = moduleId,
                        Approved = true,
                        Content = content,
                        IsActive = true,
                        IsPublished = true,
                        PortalID = portalId
                    };
                }
                else
                {
                    htmlContent.Approved = true;
                    htmlContent.Content = content;
                    htmlContent.IsActive = true;
                    htmlContent.IsPublished = true;
                    htmlContent.PortalID = portalId;
                }

                ctlHtml.UpdateHtmlText(htmlContent, maxHistory);

                return true;
            }
            catch (Exception e)
            {
                LogError(e.Message, e);
                return false;
            }
        }

        private void LogError(string message, Exception ex)
        {
            if (ex != null)
            {
                Logger.Error(message, ex);
                if (ex.InnerException != null)
                {
                    Logger.Error(ex.InnerException.Message, ex.InnerException);
                }
            }
            else
            {
                Logger.Error(message);
            }
        }
    }
}