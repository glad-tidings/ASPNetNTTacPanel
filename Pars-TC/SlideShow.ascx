<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="SlideShow.ascx.vb" Inherits="Pars_TC.SlideShow" %>

<form id="slidesh" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<script runat="server">
    Dim ServerStatus(2) As String
    Dim ColorStatus(2) As String
    
    Sub GetInfo()
        Dim Client As New Net.WebClient
        Dim ResponseT(2) As String
        Try
            ResponseT(0) = Client.DownloadString("http://localhost:81/status/us.php")
            ResponseT(1) = Client.DownloadString("http://localhost:81/status/uk.php")
            ResponseT(2) = Client.DownloadString("http://localhost:81/status/de.php")
        Catch ex As Exception
            ResponseT(0) = "u"
            ResponseT(1) = "u"
            ResponseT(2) = "u"
        End Try
        For I As Integer = 0 To 2
            Select Case ResponseT(I).ToLower
                Case "up"
                    ServerStatus(I) = "فعال"
                    ColorStatus(I) = "Green"
                Case "down"
                    ServerStatus(I) = "غیرفعال"
                    ColorStatus(I) = "Red"
                Case Else
                    ServerStatus(I) = "نامشخص"
                    ColorStatus(I) = "Yellow"
            End Select
        Next
    End Sub
  
    Private Sub SlideShowTimer_Tick(sender As Object, e As EventArgs) Handles SlideShowTimer.Tick
        GetInfo()
    End Sub
    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GetInfo()
        SlideShowTimer.Enabled = True
    End Sub
</script>
<asp:Timer ID="SlideShowTimer" runat="server" Enabled="False" Interval="60000"></asp:Timer>
</ContentTemplate>
</asp:UpdatePanel>
</form>

    <div id="rt-page-surround">
			<div class="rt-container">
            <div id="rt-slideshow">
						<div class="rt-slideshow-top"></div>
						<div class="rt-slideshow-left-top"></div>
						<div class="rt-slideshow-right-top"></div>
						<div class="rt-slideshow-left-mid"></div>
						<div class="rt-slideshow-right-mid"></div>
						<div class="rt-slideshow-right"></div>
						<div class="sprocket-features layout-slideshow" data-slideshow="163">
	<ul class="sprocket-features-img-list">
		
<li class="sprocket-features-index-1">
		<div style="opacity: 1; position: relative; z-index: 2;" class="sprocket-features-img-container" data-slideshow-image="">
				<img src="images/img1.png" alt="" style="max-width: 100%; height: auto;">
				<div class="rt-slideshow-overlay"></div>
		<div class="rt-slideshow-overlay2"></div>
	</div>
	<div style="opacity: 1; position: absolute; z-index: 2;" class="sprocket-features-content" data-slideshow-content="">
				<div class="sprocket-features-content-top"></div>
							<div class="sprocket-features-desc">
				<span>
                    <p><img src="images/fus.png" style="margin-left: 5px; margin-right: 5px; vertical-align: middle;">سرور آمریکا <span style="color:<%=ColorStatus(0)%>; font-weight:bolder; font-size:large;"><%=ServerStatus(0)%></span> است</p>
					<p style="text-align:match-parent">جهت مشاهده اطلاعات کامل وضعیت سرور در تاریخ های مختلف بر روی کلید اطلاعات بیشتر کلیک کنید.</p>
                    <p style="text-align:left"><a class="white" href="http://usstatus.pars-tc.com">اطلاعات بیشتر</a></p>
				</span>
			</div>
			</div>
</li>

<li class="sprocket-features-index-2">
		<div style="opacity: 0; position: absolute; z-index: 1; top: -50%; right: -50%;" class="sprocket-features-img-container" data-slideshow-image="">
					<img src="images/img2.png" alt="" style="max-width: 100%; height: auto;">
				<div class="rt-slideshow-overlay"></div>
		<div class="rt-slideshow-overlay2"></div>
	</div>
	<div style="opacity: 0; position: absolute; z-index: 1;" class="sprocket-features-content" data-slideshow-content="">
				<div class="sprocket-features-content-top"></div>
							<div class="sprocket-features-desc">
                <span>
					<p><img src="images/fuk.png" style="margin-left: 5px; margin-right: 5px; vertical-align: middle;">سرور انگلیس <span style="color:<%=ColorStatus(1)%>; font-weight:bolder; font-size:large;"><%=ServerStatus(1)%></span> است</p>
					<p style="text-align:match-parent">جهت مشاهده اطلاعات کامل وضعیت سرور در تاریخ های مختلف بر روی کلید اطلاعات بیشتر کلیک کنید.</p>
                    <p style="text-align:left"><a class="white" href="http://ukstatus.pars-tc.com">اطلاعات بیشتر</a></p>
				</span>				
			</div>
			</div>
	
</li>

<li class="sprocket-features-index-3">
		<div style="opacity: 0; position: absolute; z-index: 1; top: 0%; right: 0%;" class="sprocket-features-img-container" data-slideshow-image="">
					<img src="images/img3.png" alt="" style="max-width: 100%; height: auto;">
				<div class="rt-slideshow-overlay"></div>
		<div class="rt-slideshow-overlay2"></div>
	</div>
	<div style="opacity: 0; position: absolute; z-index: 1;" class="sprocket-features-content" data-slideshow-content="">
				<div class="sprocket-features-content-top"></div>
							<div class="sprocket-features-desc">
                <span>
					<p><img src="images/fde.png" style="margin-left: 5px; margin-right: 5px; vertical-align: middle;">سرور آلمان <span style="color:<%=ColorStatus(2)%>; font-weight:bolder; font-size:large;"><%=ServerStatus(2)%></span> است</p>
					<p style="text-align:match-parent">جهت مشاهده اطلاعات کامل وضعیت سرور در تاریخ های مختلف بر روی کلید اطلاعات بیشتر کلیک کنید.</p>
                    <p style="text-align:left"><a class="white" href="http://destatus.pars-tc.com">اطلاعات بیشتر</a></p>
				</span>	
				</div>
			</div>
</li>
	</ul>
		<div class="sprocket-features-arrows">
		<span class="arrow next" data-slideshow-next=""><span>›</span></span>
		<span class="arrow prev" data-slideshow-previous=""><span>‹</span></span>
	</div>
		<div class="sprocket-features-pagination">
		<ul>
						    	<li class="active" data-slideshow-pagination="1"><span>US</span></li>
						    	<li class="" data-slideshow-pagination="2"><span>UK</span></li>
						    	<li class="" data-slideshow-pagination="3"><span>DE</span></li>
				</ul>
	</div>
	
</div>
	
						<div class="rt-slideshow-left-btm"></div>
						<div class="rt-slideshow-right-btm"></div>
						<div class="rt-slideshow-btm"></div>
						<div class="clear"></div>
					</div></div></div>