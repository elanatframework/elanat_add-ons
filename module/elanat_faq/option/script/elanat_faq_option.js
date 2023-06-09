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

    document.getElementById("txt_FaqAnswer_" + ModificationIndex).id  = "txt_FaqAnswer_Modification";
    document.getElementById("txt_FaqAnswer_" + Index).name = "txt_FaqAnswer_" + ModificationIndex;
    document.getElementById("txt_FaqAnswer_" + Index).id = "txt_FaqAnswer_" + ModificationIndex;
    document.getElementById("txt_FaqAnswer_Modification").name = "txt_FaqAnswer_" + Index;
    document.getElementById("txt_FaqAnswer_Modification").id = "txt_FaqAnswer_" + Index;

    document.getElementById("txt_FaqQuestion_" + ModificationIndex).id  = "txt_FaqQuestion_Modification";
    document.getElementById("txt_FaqQuestion_" + Index).name = "txt_FaqQuestion_" + ModificationIndex;
    document.getElementById("txt_FaqQuestion_" + Index).id = "txt_FaqQuestion_" + ModificationIndex;
    document.getElementById("txt_FaqQuestion_Modification").name = "txt_FaqQuestion_" + Index;
    document.getElementById("txt_FaqQuestion_Modification").id = "txt_FaqQuestion_" + Index;

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

    document.getElementById("txt_FaqAnswer_" + ModificationIndex).id  = "txt_FaqAnswer_Modification";
    document.getElementById("txt_FaqAnswer_" + Index).name = "txt_FaqAnswer_" + ModificationIndex;
    document.getElementById("txt_FaqAnswer_" + Index).id = "txt_FaqAnswer_" + ModificationIndex;
    document.getElementById("txt_FaqAnswer_Modification").name = "txt_FaqAnswer_" + Index;
    document.getElementById("txt_FaqAnswer_Modification").id = "txt_FaqAnswer_" + Index;

    document.getElementById("txt_FaqQuestion_" + ModificationIndex).id  = "txt_FaqQuestion_Modification";
    document.getElementById("txt_FaqQuestion_" + Index).name = "txt_FaqQuestion_" + ModificationIndex;
    document.getElementById("txt_FaqQuestion_" + Index).id = "txt_FaqQuestion_" + ModificationIndex;
    document.getElementById("txt_FaqQuestion_Modification").name = "txt_FaqQuestion_" + Index;
    document.getElementById("txt_FaqQuestion_Modification").id = "txt_FaqQuestion_" + Index;

    document.getElementById("div_Index_" + ModificationIndex).id  = "div_Index_Modification";
    document.getElementById("div_Index_" + Index).id = "div_Index_" + ModificationIndex;
    document.getElementById("div_Index_Modification").id = "div_Index_" + Index;
}

function el_AddFaq()
{
    var Index = 0;

    while (document.getElementById("div_Index_" + Index))
    {
        Index++;
    }

    var xmlhttp = (window.XMLHttpRequest)? new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");

    xmlhttp.onreadystatechange = function () 
	{
        if (xmlhttp.readyState == 4 && xmlhttp.status == 200 &&  xmlhttp.responseText != "false")
        {
			var DivNewFaq = document.createElement("div");
			DivNewFaq.innerHTML = xmlhttp.responseText;
			
            document.getElementById("div_FaqBox").appendChild(DivNewFaq);     
            el_SetIframeAutoHeight();
        }

        if (xmlhttp.status != 0 && (xmlhttp.readyState == 0 || xmlhttp.status > 200))
        {
            el_Alert(LanguageVariant.ConnectionError, "problem");
        }
    }
		
    xmlhttp.open("GET", ElanatVariant.SitePath + "add_on/module/elanat_faq/option/action/AddFaq.aspx?index=" + Index, false);
    xmlhttp.send();
}

async function el_DeleteFaq(obj)
{
        var FindFaqBox = obj;

        while(FindFaqBox.parentNode)
        {
            if (FindFaqBox.parentNode.className == "el_faq_box")
                FindFaqBox.parentNode.outerHTML = "";

            FindFaqBox = FindFaqBox.parentNode;
        }
}