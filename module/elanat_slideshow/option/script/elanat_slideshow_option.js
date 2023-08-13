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

    document.getElementById("cbx_SlideshowImageActive_" + ModificationIndex).id  = "cbx_SlideshowImageActive_Modification";
    document.getElementById("cbx_SlideshowImageActive_" + Index).name = "cbx_SlideshowImageActive_" + ModificationIndex;
    document.getElementById("cbx_SlideshowImageActive_" + Index).id = "cbx_SlideshowImageActive_" + ModificationIndex;
    document.getElementById("cbx_SlideshowImageActive_Modification").name = "cbx_SlideshowImageActive_" + Index;
    document.getElementById("cbx_SlideshowImageActive_Modification").id = "cbx_SlideshowImageActive_" + Index;

    el_SetCheckBoxLabel("cbx_SlideshowImageActive_" + ModificationIndex, "cbx_SlideshowImageActive_Modification");
    el_SetCheckBoxLabel("cbx_SlideshowImageActive_" + Index, "cbx_SlideshowImageActive_" + ModificationIndex);
    el_SetCheckBoxLabel("cbx_SlideshowImageActive_Modification", "cbx_SlideshowImageActive_" + Index);

    document.getElementById("txt_SlideshowImageLink_" + ModificationIndex).id  = "txt_SlideshowImageLink_Modification";
    document.getElementById("txt_SlideshowImageLink_" + Index).name = "txt_SlideshowImageLink_" + ModificationIndex;
    document.getElementById("txt_SlideshowImageLink_" + Index).id = "txt_SlideshowImageLink_" + ModificationIndex;
    document.getElementById("txt_SlideshowImageLink_Modification").name = "txt_SlideshowImageLink_" + Index;
    document.getElementById("txt_SlideshowImageLink_Modification").id = "txt_SlideshowImageLink_" + Index;

    document.getElementById("txt_SlideshowImageText_" + ModificationIndex).id  = "txt_SlideshowImageText_Modification";
    document.getElementById("txt_SlideshowImageText_" + Index).name = "txt_SlideshowImageText_" + ModificationIndex;
    document.getElementById("txt_SlideshowImageText_" + Index).id = "txt_SlideshowImageText_" + ModificationIndex;
    document.getElementById("txt_SlideshowImageText_Modification").name = "txt_SlideshowImageText_" + Index;
    document.getElementById("txt_SlideshowImageText_Modification").id = "txt_SlideshowImageText_" + Index;

    document.getElementById("hdn_SlideshowImageName_" + ModificationIndex).id  = "hdn_SlideshowImageName_Modification";
    document.getElementById("hdn_SlideshowImageName_" + Index).name = "hdn_SlideshowImageName_" + ModificationIndex;
    document.getElementById("hdn_SlideshowImageName_" + Index).id = "hdn_SlideshowImageName_" + ModificationIndex;
    document.getElementById("hdn_SlideshowImageName_Modification").name = "hdn_SlideshowImageName_" + Index;
    document.getElementById("hdn_SlideshowImageName_Modification").id = "hdn_SlideshowImageName_" + Index;

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

    document.getElementById("cbx_SlideshowImageActive_" + ModificationIndex).id  = "cbx_SlideshowImageActive_Modification";
    document.getElementById("cbx_SlideshowImageActive_" + Index).name = "cbx_SlideshowImageActive_" + ModificationIndex;
    document.getElementById("cbx_SlideshowImageActive_" + Index).id = "cbx_SlideshowImageActive_" + ModificationIndex;
    document.getElementById("cbx_SlideshowImageActive_Modification").name = "cbx_SlideshowImageActive_" + Index;
    document.getElementById("cbx_SlideshowImageActive_Modification").id = "cbx_SlideshowImageActive_" + Index;

    el_SetCheckBoxLabel("cbx_SlideshowImageActive_" + ModificationIndex, "cbx_SlideshowImageActive_Modification");
    el_SetCheckBoxLabel("cbx_SlideshowImageActive_" + Index, "cbx_SlideshowImageActive_" + ModificationIndex);
    el_SetCheckBoxLabel("cbx_SlideshowImageActive_Modification", "cbx_SlideshowImageActive_" + Index);

    document.getElementById("txt_SlideshowImageLink_" + ModificationIndex).id  = "txt_SlideshowImageLink_Modification";
    document.getElementById("txt_SlideshowImageLink_" + Index).name = "txt_SlideshowImageLink_" + ModificationIndex;
    document.getElementById("txt_SlideshowImageLink_" + Index).id = "txt_SlideshowImageLink_" + ModificationIndex;
    document.getElementById("txt_SlideshowImageLink_Modification").name = "txt_SlideshowImageLink_" + Index;
    document.getElementById("txt_SlideshowImageLink_Modification").id = "txt_SlideshowImageLink_" + Index;

    document.getElementById("txt_SlideshowImageText_" + ModificationIndex).id  = "txt_SlideshowImageText_Modification";
    document.getElementById("txt_SlideshowImageText_" + Index).name = "txt_SlideshowImageText_" + ModificationIndex;
    document.getElementById("txt_SlideshowImageText_" + Index).id = "txt_SlideshowImageText_" + ModificationIndex;
    document.getElementById("txt_SlideshowImageText_Modification").name = "txt_SlideshowImageText_" + Index;
    document.getElementById("txt_SlideshowImageText_Modification").id = "txt_SlideshowImageText_" + Index;

    document.getElementById("hdn_SlideshowImageName_" + ModificationIndex).id  = "hdn_SlideshowImageName_Modification";
    document.getElementById("hdn_SlideshowImageName_" + Index).name = "hdn_SlideshowImageName_" + ModificationIndex;
    document.getElementById("hdn_SlideshowImageName_" + Index).id = "hdn_SlideshowImageName_" + ModificationIndex;
    document.getElementById("hdn_SlideshowImageName_Modification").name = "hdn_SlideshowImageName_" + Index;
    document.getElementById("hdn_SlideshowImageName_Modification").id = "hdn_SlideshowImageName_" + Index;

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
		
        xmlhttp.open("GET", ElanatVariant.SitePath + "add_on/module/elanat_slideshow/option/action/DeleteImage.aspx?image_name=" + ImageName, false);
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
    document.getElementById("cbx_SlideshowImageActive_tmp").name  = "cbx_SlideshowImageActive_" + LastIndex;
    document.getElementById("cbx_SlideshowImageActive_tmp").parentNode.getElementsByTagName("label").item(0).setAttribute("for", "cbx_SlideshowImageActive_" + LastIndex);
    document.getElementById("txt_SlideshowImageText_tmp").name  = "txt_SlideshowImageText_" + LastIndex;
    document.getElementById("txt_SlideshowImageLink_tmp").name  = "txt_SlideshowImageLink_" + LastIndex;
    document.getElementById("hdn_SlideshowImageName_tmp").name  = "hdn_SlideshowImageName_" + LastIndex;
    document.getElementById("cbx_SlideshowImageActive_tmp").id  = "cbx_SlideshowImageActive_" + LastIndex;
    document.getElementById("txt_SlideshowImageText_tmp").id  = "txt_SlideshowImageText_" + LastIndex;
    document.getElementById("txt_SlideshowImageLink_tmp").id  = "txt_SlideshowImageLink_" + LastIndex;
    document.getElementById("hdn_SlideshowImageName_tmp").id  = "hdn_SlideshowImageName_" + LastIndex;
    document.getElementById("div_Index_tmp").id  = "div_Index_" + LastIndex;
}