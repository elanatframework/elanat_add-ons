function el_SetToUp(Index)
{
    if (Index == 0)
        return;

    var ModificationIndex = Index - 1;

    var CurrentIndex = document.getElementById("div_Index_" + Index);
    var BeforeIndex = document.getElementById("div_Index_" + ModificationIndex);

    var CurrentIndexouterHTML = CurrentIndex.outerHTML;
    CurrentIndex.outerHTML = "";

    BeforeIndex.outerHTML = CurrentIndexouterHTML + BeforeIndex.outerHTML;


    document.getElementById("btn_SetToUp_" + ModificationIndex).id  = "btn_SetToUp_Modification";
    document.getElementById("btn_SetToDown_" + ModificationIndex).id = "btn_SetToDown_Modification";
    document.getElementById("btn_SetToUp_" + Index).setAttribute("onclick", "el_SetToUp(" + ModificationIndex + ")");
    document.getElementById("btn_SetToDown_" + Index).setAttribute("onclick", "el_SetToDown(" + ModificationIndex + ")");
    document.getElementById("btn_SetToUp_" + Index).id = "btn_SetToUp_" + ModificationIndex;
    document.getElementById("btn_SetToDown_" + Index).id  = "btn_SetToDown_" + ModificationIndex;
    document.getElementById("btn_SetToUp_Modification").setAttribute("onclick", "el_SetToUp(" + Index + ")");
    document.getElementById("btn_SetToDown_Modification").setAttribute("onclick", "el_SetToDown(" + Index + ")");
    document.getElementById("btn_SetToUp_Modification").id  = "btn_SetToUp_" + Index;
    document.getElementById("btn_SetToDown_Modification").id = "btn_SetToDown_" + Index;

    document.getElementById("cbx_GalleryImageActive_" + ModificationIndex).id  = "cbx_GalleryImageActive_Modification";
    document.getElementById("cbx_GalleryImageActive_" + Index).name = "cbx_GalleryImageActive_" + ModificationIndex;
    document.getElementById("cbx_GalleryImageActive_" + Index).id = "cbx_GalleryImageActive_" + ModificationIndex;
    document.getElementById("cbx_GalleryImageActive_Modification").name = "cbx_GalleryImageActive_" + Index;
    document.getElementById("cbx_GalleryImageActive_Modification").id = "cbx_GalleryImageActive_" + Index;

    el_SetCheckBoxLabel("cbx_GalleryImageActive_" + ModificationIndex, "cbx_GalleryImageActive_Modification");
    el_SetCheckBoxLabel("cbx_GalleryImageActive_" + Index, "cbx_GalleryImageActive_" + ModificationIndex);
    el_SetCheckBoxLabel("cbx_GalleryImageActive_Modification", "cbx_GalleryImageActive_" + Index);

    document.getElementById("txt_GalleryImageText_" + ModificationIndex).id  = "txt_GalleryImageText_Modification";
    document.getElementById("txt_GalleryImageText_" + Index).name = "txt_GalleryImageText_" + ModificationIndex;
    document.getElementById("txt_GalleryImageText_" + Index).id = "txt_GalleryImageText_" + ModificationIndex;
    document.getElementById("txt_GalleryImageText_Modification").name = "txt_GalleryImageText_" + Index;
    document.getElementById("txt_GalleryImageText_Modification").id = "txt_GalleryImageText_" + Index;

    document.getElementById("hdn_GalleryImageName_" + ModificationIndex).id  = "hdn_GalleryImageName_Modification";
    document.getElementById("hdn_GalleryImageName_" + Index).name = "hdn_GalleryImageName_" + ModificationIndex;
    document.getElementById("hdn_GalleryImageName_" + Index).id = "hdn_GalleryImageName_" + ModificationIndex;
    document.getElementById("hdn_GalleryImageName_Modification").name = "hdn_GalleryImageName_" + Index;
    document.getElementById("hdn_GalleryImageName_Modification").id = "hdn_GalleryImageName_" + Index;

    document.getElementById("div_Index_" + ModificationIndex).id  = "div_Index_Modification";
    document.getElementById("div_Index_" + Index).id = "div_Index_" + ModificationIndex;
    document.getElementById("div_Index_Modification").id = "div_Index_" + Index;
}

function el_SetToDown(Index)
{
    var ModificationIndex = Index + 1;

    if (!document.getElementById("div_Index_" + ModificationIndex))
        return;

    var CurrentIndex = document.getElementById("div_Index_" + Index);
    var AfterIndex = document.getElementById("div_Index_" + ModificationIndex);

    var CurrentIndexouterHTML = CurrentIndex.outerHTML;
    CurrentIndex.outerHTML = "";

    AfterIndex.outerHTML = AfterIndex.outerHTML + CurrentIndexouterHTML;


    document.getElementById("btn_SetToUp_" + ModificationIndex).id  = "btn_SetToUp_Modification";
    document.getElementById("btn_SetToDown_" + ModificationIndex).id = "btn_SetToDown_Modification";
    document.getElementById("btn_SetToUp_" + Index).setAttribute("onclick", "el_SetToUp(" + ModificationIndex + ")");
    document.getElementById("btn_SetToDown_" + Index).setAttribute("onclick", "el_SetToDown(" + ModificationIndex + ")");
    document.getElementById("btn_SetToUp_" + Index).id = "btn_SetToUp_" + ModificationIndex;
    document.getElementById("btn_SetToDown_" + Index).id  = "btn_SetToDown_" + ModificationIndex;
    document.getElementById("btn_SetToUp_Modification").setAttribute("onclick", "el_SetToUp(" + Index + ")");
    document.getElementById("btn_SetToDown_Modification").setAttribute("onclick", "el_SetToDown(" + Index + ")");
    document.getElementById("btn_SetToUp_Modification").id  = "btn_SetToUp_" + Index;
    document.getElementById("btn_SetToDown_Modification").id = "btn_SetToDown_" + Index;

    document.getElementById("cbx_GalleryImageActive_" + ModificationIndex).id  = "cbx_GalleryImageActive_Modification";
    document.getElementById("cbx_GalleryImageActive_" + Index).name = "cbx_GalleryImageActive_" + ModificationIndex;
    document.getElementById("cbx_GalleryImageActive_" + Index).id = "cbx_GalleryImageActive_" + ModificationIndex;
    document.getElementById("cbx_GalleryImageActive_Modification").name = "cbx_GalleryImageActive_" + Index;
    document.getElementById("cbx_GalleryImageActive_Modification").id = "cbx_GalleryImageActive_" + Index;

    el_SetCheckBoxLabel("cbx_GalleryImageActive_" + ModificationIndex, "cbx_GalleryImageActive_Modification");
    el_SetCheckBoxLabel("cbx_GalleryImageActive_" + Index, "cbx_GalleryImageActive_" + ModificationIndex);
    el_SetCheckBoxLabel("cbx_GalleryImageActive_Modification", "cbx_GalleryImageActive_" + Index);

    document.getElementById("txt_GalleryImageText_" + ModificationIndex).id  = "txt_GalleryImageText_Modification";
    document.getElementById("txt_GalleryImageText_" + Index).name = "txt_GalleryImageText_" + ModificationIndex;
    document.getElementById("txt_GalleryImageText_" + Index).id = "txt_GalleryImageText_" + ModificationIndex;
    document.getElementById("txt_GalleryImageText_Modification").name = "txt_GalleryImageText_" + Index;
    document.getElementById("txt_GalleryImageText_Modification").id = "txt_GalleryImageText_" + Index;

    document.getElementById("hdn_GalleryImageName_" + ModificationIndex).id  = "hdn_GalleryImageName_Modification";
    document.getElementById("hdn_GalleryImageName_" + Index).name = "hdn_GalleryImageName_" + ModificationIndex;
    document.getElementById("hdn_GalleryImageName_" + Index).id = "hdn_GalleryImageName_" + ModificationIndex;
    document.getElementById("hdn_GalleryImageName_Modification").name = "hdn_GalleryImageName_" + Index;
    document.getElementById("hdn_GalleryImageName_Modification").id = "hdn_GalleryImageName_" + Index;

    document.getElementById("div_Index_" + ModificationIndex).id  = "div_Index_Modification";
    document.getElementById("div_Index_" + Index).id = "div_Index_" + ModificationIndex;
    document.getElementById("div_Index_Modification").id = "div_Index_" + Index;
}

async function el_DeleteImage(obj, ImageName)
{
	var OkClick = await el_Confirm(LanguageVariant.AreYouSureWantToDelete);
    if (OkClick)
    {
        var xmlhttp = (window.XMLHttpRequest)? new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

        xmlhttp.onreadystatechange = function () 
		{
            if (xmlhttp.readyState == 4 && xmlhttp.status == 200 && xmlhttp.responseText == "true")
            {
                var FindImageBox = obj;

                while(FindImageBox.parentNode)
                {
                    if (FindImageBox.parentNode.className == "el_image_box")
                        FindImageBox.parentNode.outerHTML = "";

                    FindImageBox = FindImageBox.parentNode;
                }
            }

            if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
            {
                el_Alert(LanguageVariant.ConnectionError, "problem");
            }
        }
		
        xmlhttp.open("GET", ElanatVariant.SitePath + "add_on/module/elanat_gallery/option/action/DeleteImage.aspx?image_name=" + ImageName, false);
        xmlhttp.send();
    }
    else
	    return false;
}

function el_SetCheckBoxLabel(OldName, NewName)
{
    var LabelArray = document.getElementsByTagName('label');
    for (var i = 0; i < LabelArray.length; i++)
    {
        if (LabelArray[i].htmlFor == OldName)
            {
                LabelArray[i].htmlFor = NewName;       
                break;
            }
    }
}

function el_SetLastIndex()
{
    var ImageBoxArray = document.getElementsByClassName("el_image_box");
    var LastIndex = 0;

    if(ImageBoxArray.length > 1)
        LastIndex = parseInt(ImageBoxArray.item(ImageBoxArray.length - 2).id.GetTextAfter("div_Index_")) + 1;


    document.getElementById("btn_SetToUp_tmp").setAttribute("onclick", "el_SetToUp(" + LastIndex + ")");
    document.getElementById("btn_SetToDown_tmp").setAttribute("onclick", "el_SetToDown(" + LastIndex + ")");
    document.getElementById("btn_SetToUp_tmp").id  = "btn_SetToUp_" + LastIndex;
    document.getElementById("btn_SetToDown_tmp").id = "btn_SetToDown_" + LastIndex;
    document.getElementById("cbx_GalleryImageActive_tmp").name  = "cbx_GalleryImageActive_" + LastIndex;
    document.getElementById("cbx_GalleryImageActive_tmp").parentNode.getElementsByTagName("label").item(0).setAttribute("for", "cbx_GalleryImageActive_" + LastIndex);
    document.getElementById("txt_GalleryImageText_tmp").name  = "txt_GalleryImageText_" + LastIndex;
    document.getElementById("hdn_GalleryImageName_tmp").name  = "hdn_GalleryImageName_" + LastIndex;
    document.getElementById("cbx_GalleryImageActive_tmp").id  = "cbx_GalleryImageActive_" + LastIndex;
    document.getElementById("txt_GalleryImageText_tmp").id  = "txt_GalleryImageText_" + LastIndex;
    document.getElementById("hdn_GalleryImageName_tmp").id  = "hdn_GalleryImageName_" + LastIndex;
    document.getElementById("div_Index_tmp").id  = "div_Index_" + LastIndex;
}