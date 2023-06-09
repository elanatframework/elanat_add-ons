<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="elanat.ModuleElanatGalleryOption" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.ElanatGalleryLanguage%></title>
    <script type="text/javascript" src="<%=elanat.AspxHtmlValue.SitePath()%>add_on/module/elanat_gallery/option/script/elanat_gallery_option.js"></script>
    <script type="text/javascript" src="<%=elanat.AspxHtmlValue.SitePath()%>action/text_creator/admin_client_variant"></script>
    <script type="text/javascript" src="<%=elanat.AspxHtmlValue.SitePath()%>action/text_creator/admin_client_language_variant/"></script>
    <script src="<%=elanat.AspxHtmlValue.SitePath()%>client/script/global.js"></script>
    <link rel="stylesheet" type="text/css" <%%>href="<%=elanat.AspxHtmlValue.SitePath()%>add_on/module/elanat_gallery/option/style/elanat_gallery_option.css" />
    <link rel="stylesheet" type="text/css" <%%>href="<%=elanat.AspxHtmlValue.SitePath()%>client/style/global.css" />
</head>
<body onload="el_PartPageLoad();">

    <form id="frm_ModuleElanatGalleryOption" method="post" action="<%=elanat.AspxHtmlValue.SitePath()%>add_on/module/elanat_gallery/option/Default.aspx">

        <div class="el_head">
            <%=model.ElanatGalleryLanguage%>
        </div>
        <div class="el_part_row">
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_GalleryUseInternalBox" name="cbx_GalleryUseInternalBox" type="checkbox" <%=elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.GalleryUseInternalBoxValue)%> /><label for="cbx_GalleryUseInternalBox"><%=model.GalleryUseInternalBoxLanguage%></label></span>
            </div>
            <div class="el_item">
                <input id="btn_SaveElanatGalleryOption" name="btn_SaveElanatGalleryOption" type="submit" class="el_button_input" value="<%=model.SaveElanatGalleryOptionLanguage%>" onclick="el_AjaxPostBack(this, false, 'frm_ModuleElanatGalleryOption')" />
            </div>
        </div>

    </form>

    <form id="frm_ModuleElanatGalleryUploadImage" method="post" action="<%=elanat.AspxHtmlValue.SitePath()%>add_on/module/elanat_gallery/option/Default.aspx" enctype="multipart/form-data">
        
        <div class="el_head">
            <%=model.ElanatGalleryUploadImageLanguage%>
        </div>
        <div class="el_part_row">
            <div id="div_UploadImageTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <%=model.UploadImageLanguage%>
                <div class="el_dash"></div>
            </div>
            <div class="el_item">
                <%=model.ImagePathLanguage%>
            </div>
            <div class="el_item">
                <input id="upd_ImagePath" name="upd_ImagePath" type="file" class="el_file_input" />
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_UseImagePath" name="cbx_UseImagePath" type="checkbox" <%=elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.UseImagePathValue)%> /><label for="cbx_UseImagePath"><%=model.UseImagePathLanguage%></label></span>
            </div>
            <div class="el_item">
                <input id="txt_ImagePath" name="txt_ImagePath" value="<%=model.ImagePathTextValue%>" type="text" class="el_long_text_input el_foreign_path" />
            </div>
            <div class="el_item">
                <input id="btn_StartUpload" name="btn_StartUpload" type="submit" class="el_button_input" value="<%=model.StartUploadLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_ModuleElanatGalleryUploadImage')" />
            </div>
        </div>

    </form>

    <form id="frm_ModuleElanatGalleryImages" method="post" action="<%=elanat.AspxHtmlValue.SitePath()%>add_on/module/elanat_gallery/option/Default.aspx">

        <div class="el_head">
            <%=model.ElanatGalleryImagesLanguage%>
        </div>
        <div class="el_part_row">
            <div class="el_item">
                <input id="btn_Refresh" type="button" class="el_button_input" value="<%=model.RefreshLanguage%>" onclick="el_Refresh()" />
            </div>
            <div id="div_ImageBoxList">
                <%=model.GalleryImageItemValue%>
            </div>
            <div class="el_item">
                <input id="btn_SaveElanatGalleryImages" name="btn_SaveElanatGalleryImages" type="submit" class="el_button_input" value="<%=model.SaveElanatGalleryImagesLanguage%>" onclick="el_AjaxPostBack(this, false, 'frm_ModuleElanatGalleryImages')" />
            </div>
        </div>

    </form>

</body>
</html>