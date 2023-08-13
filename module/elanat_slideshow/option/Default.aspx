<%@ Page Controller="Elanat.ModuleElanatSlideshowOptionController" Model="Elanat.ModuleElanatSlideshowOptionModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=Elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.ElanatSlideshowLanguage%></title>
    <script type="text/javascript" src="<%=Elanat.AspxHtmlValue.SitePath()%>add_on/module/elanat_slideshow/option/script/elanat_slideshow_option.js"></script>
    <script type="text/javascript" src="<%=Elanat.AspxHtmlValue.SitePath()%>action/text_creator/admin_client_variant"></script>
    <script type="text/javascript" src="<%=Elanat.AspxHtmlValue.SitePath()%>action/text_creator/admin_client_language_variant/"></script>
    <script src="<%=Elanat.AspxHtmlValue.SitePath()%>client/script/global.js"></script>
    <link rel="stylesheet" type="text/css" href="<%=Elanat.AspxHtmlValue.SitePath()%>add_on/module/elanat_slideshow/option/style/elanat_slideshow_option.css" />
    <link rel="stylesheet" type="text/css" href="<%=Elanat.AspxHtmlValue.SitePath()%>client/style/global.css" />
</head>
<body onload="el_PartPageLoad();">

    <form id="frm_ModuleElanatSlideshowOption" method="post" action="<%=Elanat.AspxHtmlValue.SitePath()%>add_on/module/elanat_slideshow/option/Default.aspx">

        <div class="el_head">
            <%=model.ElanatSlideshowLanguage%>
        </div>
        <div class="el_part_row">
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_SlideshowUseInternalBox" name="cbx_SlideshowUseInternalBox" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.SlideshowUseInternalBoxValue)%> /><label for="cbx_SlideshowUseInternalBox"><%=model.SlideshowUseInternalBoxLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_SlideshowUseMaxWidth" name="cbx_SlideshowUseMaxWidth" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.SlideshowUseMaxWidthValue)%> /><label for="cbx_SlideshowUseMaxWidth"><%=model.SlideshowUseMaxWidthLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_IncludeText" name="cbx_IncludeText" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.IncludeTextValue)%> /><label for="cbx_IncludeText"><%=model.IncludeTextLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_UseTextBackground" name="cbx_UseTextBackground" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.UseTextBackgroundValue)%> /><label for="cbx_UseTextBackground"><%=model.UseTextBackgroundLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.SlideshowWidthLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_SlideshowWidth" name="txt_SlideshowWidth" type="number" value="<%=model.SlideshowWidthValue%>" class="el_text_input<%=model.SlideshowWidthCssClass%>" <%=model.SlideshowWidthAttribute%> />
            </div>
            <div class="el_item">
                <%=model.SlideshowHeightLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_SlideshowHeight" name="txt_SlideshowHeight" type="number" value="<%=model.SlideshowHeightValue%>" class="el_text_input<%=model.SlideshowHeightCssClass%>" <%=model.SlideshowHeightAttribute%> />
            </div>
            <div class="el_item">
                <%=model.ChangeSlideDelayLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_ChangeSlideDelay" name="txt_ChangeSlideDelay" type="number" value="<%=model.ChangeSlideDelayValue%>" class="el_text_input<%=model.ChangeSlideDelayCssClass%>" <%=model.ChangeSlideDelayAttribute%> />
            </div>
            <div class="el_item">
                <%=model.SlideImageObjectFitLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_SlideImageObjectFit" name="ddlst_SlideImageObjectFit" class="el_alone_select_input<%=model.SlideImageObjectFitCssClass%>" <%=model.SlideImageObjectFitAttribute%>><%=model.SlideImageObjectFitOptionListValue%></select>
            </div>
            <div class="el_item">
                <%=model.TextLocationLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_TextLocation" name="ddlst_TextLocation" class="el_alone_select_input<%=model.TextLocationCssClass%>" <%=model.TextLocationAttribute%>><%=model.TextLocationOptionListValue%></select>
            </div>
            <div class="el_item">
                <%=model.ChangeSlideAnimationLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_ChangeSlideAnimation" name="ddlst_ChangeSlideAnimation" class="el_alone_select_input<%=model.ChangeSlideAnimationCssClass%>" <%=model.ChangeSlideAnimationAttribute%>><%=model.ChangeSlideAnimationOptionListValue%></select>
            </div>
            <div class="el_item">
                <%=model.TextStyleLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_TextStyle" name="txt_TextStyle" type="text" value="<%=model.TextStyleValue%>" class="el_long_text_input el_left_to_right<%=model.TextStyleCssClass%>" <%=model.TextStyleAttribute%> />
            </div>
            <div class="el_item">
                <input id="btn_SaveElanatSlideshowOption" name="btn_SaveElanatSlideshowOption" type="submit" class="el_button_input" value="<%=model.SaveElanatSlideshowOptionLanguage%>" onclick="el_AjaxPostBack(this, false, 'frm_ModuleElanatSlideshowOption')" />
            </div>
        </div>

    </form>

    <form id="frm_ModuleElanatSlideshowUploadImage" method="post" action="<%=Elanat.AspxHtmlValue.SitePath()%>add_on/module/elanat_slideshow/option/Default.aspx" enctype="multipart/form-data">
        
        <div class="el_head">
            <%=model.ElanatSlideshowUploadImageLanguage%>
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
                <span class="el_checkbox_input"><input id="cbx_UseImagePath" name="cbx_UseImagePath" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.UseImagePathValue)%> /><label for="cbx_UseImagePath"><%=model.UseImagePathLanguage%></label></span>
            </div>
            <div class="el_item">
                <input id="txt_ImagePath" name="txt_ImagePath" value="<%=model.ImagePathTextValue%>" type="text" class="el_long_text_input el_foreign_path" />
            </div>
            <div class="el_item">
                <input id="btn_StartUpload" name="btn_StartUpload" type="submit" class="el_button_input" value="<%=model.StartUploadLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_ModuleElanatSlideshowUploadImage')" />
            </div>
        </div>

    </form>

    <form id="frm_ModuleElanatSlideshowImages" method="post" action="<%=Elanat.AspxHtmlValue.SitePath()%>add_on/module/elanat_slideshow/option/Default.aspx">

        <div class="el_head">
            <%=model.ElanatSlideshowImagesLanguage%>
        </div>
        <div class="el_part_row">
            <div class="el_item">
                <input id="btn_Refresh" type="button" class="el_button_input" value="<%=model.RefreshLanguage%>" onclick="el_Refresh()" />
            </div>
			<div id="div_ImageBoxList">
				<%=model.SlideshowImageItemValue%>
			</div>
            <div class="el_item">
                <input id="btn_SaveElanatSlideshowImages" name="btn_SaveElanatSlideshowImages" type="submit" class="el_button_input" value="<%=model.SaveElanatSlideshowImagesLanguage%>" onclick="el_AjaxPostBack(this, false, 'frm_ModuleElanatSlideshowImages')" />
            </div>
        </div>

    </form>

</body>
</html>