<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="elanat.ModuleElanatFaqOption" validateRequest="false" enableEventValidation="false" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.ElanatFaqLanguage%></title>
    <script type="text/javascript" src="<%=elanat.AspxHtmlValue.SitePath()%>add_on/module/elanat_faq/option/script/elanat_faq_option.js"></script>
    <script type="text/javascript" src="<%=elanat.AspxHtmlValue.SitePath()%>action/text_creator/admin_client_variant"></script>
    <script type="text/javascript" src="<%=elanat.AspxHtmlValue.SitePath()%>action/text_creator/admin_client_language_variant/"></script>
    <script src="<%=elanat.AspxHtmlValue.SitePath()%>client/script/global.js"></script>
    <link rel="stylesheet" type="text/css" <%%>href="<%=elanat.AspxHtmlValue.SitePath()%>add_on/module/elanat_faq/option/style/elanat_faq_option.css" />
    <link rel="stylesheet" type="text/css" <%%>href="<%=elanat.AspxHtmlValue.SitePath()%>client/style/global.css" />
</head>
<body onload="el_PartPageLoad();">

    <form id="frm_ModuleElanatFaqOption" method="post" action="<%=elanat.AspxHtmlValue.SitePath()%>add_on/module/elanat_faq/option/Default.aspx">

        <div class="el_head">
            <%=model.ElanatFaqLanguage%>
        </div>
        <div class="el_part_row">
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_FaqUseInternalBox" name="cbx_FaqUseInternalBox" type="checkbox" <%=elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.FaqUseInternalBoxValue)%> /><label for="cbx_FaqUseInternalBox"><%=model.FaqUseInternalBoxLanguage%></label></span>
            </div>
            <div class="el_item">
                <input id="btn_SaveElanatFaqOption" name="btn_SaveElanatFaqOption" type="submit" class="el_button_input" value="<%=model.SaveElanatFaqOptionLanguage%>" onclick="el_AjaxPostBack(this, false, 'frm_ModuleElanatFaqOption')" />
            </div>
        </div>

    </form>

    <form id="frm_ModuleElanatFaqs" method="post" action="<%=elanat.AspxHtmlValue.SitePath()%>add_on/module/elanat_faq/option/Default.aspx">

        <div class="el_head">
            <%=model.ElanatFaqsLanguage%>
        </div>
        <div class="el_part_row">
            <div class="el_item" id="div_FaqBox">
                <%=model.FaqItemValue%>
            </div>
            <div class="el_item">
                <input type="button" value="<%=model.AddLanguage%>" class="el_button_input" onclick="el_AddFaq()" />
            </div>
            <div class="el_item">
                <input id="btn_SaveElanatFaqs" name="btn_SaveElanatFaqs" type="submit" class="el_button_input" value="<%=model.SaveElanatFaqsLanguage%>" onclick="el_AjaxPostBack(this, false, 'frm_ModuleElanatFaqs')" />
            </div>
        </div>

    </form>

</body>
</html>