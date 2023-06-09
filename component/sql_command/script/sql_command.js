function el_DeleteTableValue()
{
    document.getElementById("div_SqlQueryTable").innerHTML = null;
}

function el_AddScrollBar()
{
    setTimeout(el_AddScrollBarAfterTimeout, 1000);
}

function el_AddScrollBarAfterTimeout()
{
    document.getElementById("div_SqlQueryTable").className = document.getElementById("div_SqlQueryTable").className.AddHtmlClass("el_use_scroll");
	el_SetIframeAutoHeight();
}

function el_DeleteScrollBar()
{
    document.getElementById("div_SqlQueryTable").className = document.getElementById("div_SqlQueryTable").className.DeleteHtmlClass("el_use_scroll");
}