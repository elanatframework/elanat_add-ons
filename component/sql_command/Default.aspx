<%@ Page Controller="Elanat.AdminSqlCommandController" Model="Elanat.AdminSqlCommandModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=Elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.SqlCommandLanguage%></title>
    <script src="<%=Elanat.AspxHtmlValue.AdminPath()%>/sql_command/script/sql_command.js"></script>
    <link rel="stylesheet" type="text/css" href="<%=Elanat.AspxHtmlValue.AdminPath()%>/sql_command/style/sql_command.css" />
    <!-- Start Client Variant -->
    <script type="text/javascript" src="<%=Elanat.AspxHtmlValue.SitePath()%>action/text_creator/admin_client_variant"></script>
    <script type="text/javascript" src="<%=Elanat.AspxHtmlValue.SitePath()%>action/text_creator/admin_client_language_variant"></script>
    <!-- End Client Variant -->	
    <script src="<%=Elanat.AspxHtmlValue.SitePath()%>client/script/global.js"></script>
    <script type="text/javascript" src="<%=Elanat.AspxHtmlValue.SitePath()%>client/script/admin/admin.js" ></script>
    <script type="text/javascript" src="<%=Elanat.AspxHtmlValue.SitePath()%>client/script/page_load/admin/page_load.js" ></script>
    <%=Elanat.AspxHtmlValue.CurrentAdminStyleTag()%>
    <link rel="stylesheet" type="text/css" href="<%=Elanat.AspxHtmlValue.SitePath()%>client/style/global.css" />
    <link rel="stylesheet" type="text/css" href="<%=Elanat.AspxHtmlValue.SitePath()%>client/style/admin_global.css" />
    <%=Elanat.AspxHtmlValue.CurrentBoxTag()%>
</head>
<body onload="el_CreateWysiwyg(); el_RunAction(); el_PartPageLoad();">

    <div class="el_head">
        <%=model.SqlCommandLanguage%>
    </div>

    <form id="frm_AdminSqlCommand" method="post" action="<%=Elanat.AspxHtmlValue.AdminPath()%>/sql_command/Default.aspx">

        <div class="el_part_row">
            <div id="div_SetSqlCommandTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <%=model.SetSqlCommandLanguage%>
                <div class="el_dash"></div>
            </div>
            <div class="el_item">
                <%=model.SqlQueryLanguage%>
            </div>
            <div class="el_item">
                <textarea id="txt_SqlQuery" name="txt_SqlQuery" class="el_textarea_input el_left_to_right<%=model.SqlQueryCssClass%>" <%=model.SqlQueryAttribute%>><%=model.SqlQueryValue%></textarea>
            </div>
            <div class="el_item">
                <input id="btn_RunSqlQuery" name="btn_RunSqlQuery" type="submit" class="el_button_input" value="<%=model.RunSqlQueryLanguage%>" onclick="el_DeleteTableValue();el_DeleteScrollBar();el_AjaxPostBack(this, true, 'frm_AdminSqlCommand');el_AddScrollBar()" />
            </div>
        </div>

    </form>

    <div class="el_part_row">
        <div class="el_item">
            <div id="div_SqlQueryTable">

            </div>
         </div>
    </div>

</body>
</html>
