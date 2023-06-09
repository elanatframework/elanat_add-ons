<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="elanat.ModuleElanatSlideshow" %>
<!-- Start Elanat Slideshow -->
<div class="el_slideshow" style="max-width:<%=model.SlideshowWidth%>;height:<%=model.SlideshowHeight%>;" onmousemove="el_StopNextSlideInterval()" onmouseout="el_StartNextSlideInterval()">
        <%=model.SlideItem%>
        <div class="el_next" style="margin-top:-<%=model.ChangeSlideCenterLocationValue%>px" onclick="el_NextSlide()"></div>
        <div class="el_previous" style="margin-top:-<%=model.ChangeSlideCenterLocationValue%>px" onclick="el_PreviouSlide()"></div>
        <div class="el_change_slide_under_icon">
          <%=model.ChangeSlideUnderIconItem%>
        </div>
      </div>
      
      <script>
        var SetNextSlideInterval = setInterval(function(){ el_NextSlide(); }, <%=model.ChangeSlideDelay%>);     
          
        function el_RefreshNextSlideInterval()
        {
            clearInterval(SetNextSlideInterval);
            SetNextSlideInterval = setInterval(function(){ el_NextSlide(); }, <%=model.ChangeSlideDelay%>);
        }
        
        function el_StartNextSlideInterval()
        {
            clearInterval(SetNextSlideInterval);
            SetNextSlideInterval = setInterval(function(){ el_NextSlide(); }, <%=model.ChangeSlideDelay%>);
        }
        
        function el_StopNextSlideInterval()
        {
            clearInterval(SetNextSlideInterval);
        }
        
        var ChangeSlideAnimation = "<%=model.ChangeSlideAnimation%>";
      
        <%=model.SlideshowInnerScriptValue%>

      </script>
      
      <style>
        <%=model.SlideshowAnimationTemplate%>
      
        <%=model.SlideshowInnerStyleValue%>
      </style>
<!-- End Elanat Slideshow -->