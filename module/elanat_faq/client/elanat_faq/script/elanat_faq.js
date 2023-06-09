function el_ShowFaq(TagId)
{
    if (document.getElementById(TagId).className.Contains("el_hide"))
        document.getElementById(TagId).className = document.getElementById(TagId).className.DeleteHtmlClass("el_hide");
    else
        document.getElementById(TagId).className = document.getElementById(TagId).className.AddHtmlClass("el_hide");
}