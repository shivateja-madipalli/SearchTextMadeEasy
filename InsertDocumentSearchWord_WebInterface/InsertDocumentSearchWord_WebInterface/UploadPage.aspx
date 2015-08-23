<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadPage.aspx.cs" Inherits="InsertDocumentSearchWord_WebInterface.UploadPage" %>

<!DOCTYPE html>



<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="bootstrap-3.3.2-dist/css/bootstrap.css" rel="stylesheet" />
    <title></title>
    <script language ="javascript" type = "text/javascript">
        
        
        function myFunction() {
            var fileUploader = document.getElementById('DummyFileUploader');
            fileUploader.click();
            
        }

        function OnClickOfUploader() {
            //dummy btn click to redirect to server side fxn
            DummyButtonForClick.click();

        }
        
        //function OnClickOfUploader() {
           
        //    //alert("dfdf");
        //    PageMethods.CalledFromClient("",OnGetMessageSuccess, OnGetMessageFailure);
        //    alert("dfdf1");
        //}
        //function OnGetMessageSuccess(result, userContext, methodName) {
        //    alert(result);
        //}
        //function OnGetMessageFailure(error, userContext, methodName) {
        //    alert(error.get_message());
        //}


        

        //function handleDragOver(evt) {
        //  evt.stopPropagation();
        //  evt.preventDefault();
        //  evt.dataTransfer.dropEffect = 'copy'; // Explicitly show this is a copy.
        //}

        //function handleFileSelect(evt) {
        //    evt.stopPropagation();
        //    evt.preventDefault();

        //    var files = evt.dataTransfer.files; // FileList object.

        //    // files is a FileList of File objects. List some properties.
        //    var output = [];
        //    for (var i = 0, f; f = files[i]; i++) {
        //        output.push('<li><strong>', escape(f.name), '</strong> (', f.type || 'n/a', ') - ',
        //                    f.size, ' bytes, last modified: ',
        //                    f.lastModifiedDate ? f.lastModifiedDate.toLocaleDateString() : 'n/a',
        //                    '</li>');
        //    }
        //    document.getElementById('list').innerHTML = '<ul>' + output.join('') + '</ul>';
        //}
</script>

</head>
<body>
    <form id="form1" runat="server">
       <!-- <asp:scriptmanager  EnablePageMethods="true" id="scpt" runat="server"> </asp:scriptmanager> -->
        <div>
            <!--header-->
            <div class="page-header">
                <h1 style="font-family:'Book Antiqua';">SMART FILE UPLOADER<small style="font-family:Century;font-style:italic">&nbsp upload file to search later</small></h1>
            </div>
            <div class="btn-group btn-group-justified" role="group" aria-label="...">
                <div class="btn-group btn-group-lg" role="group">
                    <button type="button" class="btn btn-danger" style="height: 70px;" onclick="myFunction()" font-family: 'Comic Sans MS'">CLICK TO UPLOAD</button>
                </div>                
            </div>
            <div style="visibility:hidden">
                
                    <asp:FileUpload runat="server" ID="DummyFileUploader" onchange="OnClickOfUploader()" Visible="true" style="width:1px;height:1px" />
                    <asp:Button runat="server" ID="DummyButtonForClick" OnClick ="DummyButtonForClick_Click"  style="width:1px;height:1px" />
                </div>
            <%--<div class="btn-group-justified" ondragover="handleDragOver(this)" ondrop="handleFileSelect(this)" style="height:300px;background-color:black">
                <output id="list"></output>--%>

            <%--</div>--%>

        </div>
    </form>
</body>
</html>
