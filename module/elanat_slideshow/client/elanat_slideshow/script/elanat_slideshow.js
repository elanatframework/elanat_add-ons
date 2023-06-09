function el_SetCleanSlider()
{
    el_RefreshNextSlideInterval();

    var SlideImage = document.getElementsByClassName("el_slideshow_image");

    var i = 0;
    for (i; i < SlideImage.length; i++)
    {
        if (SlideImage.item(i).className.Contains("el_show"))
        {
            SlideImage.item(i).className = SlideImage.item(i).className.DeleteHtmlClass("el_show");
            SlideImage.item(i).className = SlideImage.item(i).className.AddHtmlClass("el_hide");

            break;
        }
    }

    return i;
}

function el_ChangeSlide(SlideNumber)
{
    var SlideImage = document.getElementsByClassName("el_slideshow_image");

    el_SetCleanSlider();

    SlideImage.item(SlideNumber).className = SlideImage.item(SlideNumber).className.DeleteHtmlClass("el_hide");
    SlideImage.item(SlideNumber).className = SlideImage.item(SlideNumber).className.AddHtmlClass("el_show");

    el_SetSelectSlideIcon(SlideNumber);
}

function el_NextSlide()
{
    var SlideImage = document.getElementsByClassName("el_slideshow_image");

    var i = el_SetCleanSlider();

    i = (i == (SlideImage.length - 1))? 0 : i + 1;

    SlideImage.item(i).className = SlideImage.item(i).className.DeleteHtmlClass("el_hide");
    SlideImage.item(i).className = SlideImage.item(i).className.AddHtmlClass("el_show");

    el_SetSelectSlideIcon(i);
}

function el_PreviouSlide()
{
    var SlideImage = document.getElementsByClassName("el_slideshow_image");

    var i = el_SetCleanSlider();

    i = (i == 0)? SlideImage.length - 1 : i - 1;

    SlideImage.item(i).className = SlideImage.item(i).className.DeleteHtmlClass("el_hide");
    SlideImage.item(i).className = SlideImage.item(i).className.AddHtmlClass("el_show");

    el_SetSelectSlideIcon(i);
}

function el_SetSelectSlideIcon(SlideNumber)
{
    var ChangeSlideIcon = document.getElementsByClassName("el_change_slide_icon");

    for (var i = 0; i < ChangeSlideIcon.length; i++)
    {
        ChangeSlideIcon.item(i).className = ChangeSlideIcon.item(i).className.DeleteHtmlClass("el_select");
    }

    ChangeSlideIcon.item(SlideNumber).className = ChangeSlideIcon.item(SlideNumber).className.AddHtmlClass("el_select");
}