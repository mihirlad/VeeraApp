<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MAC_ADDRESSS.aspx.cs" Inherits="VeeraApp.MAC_ADDRESSS" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <script src="js/jquery.js"></script>
  <title>Sample Code for Getting Client MAC Address From JavaScript (IE Only)</title>
    <script src="scripts/jquery-2.0.3.js"></script>
 <script lang="javascript" type="text/javascript" >

  $(document).ready(function () {
         $("#<%=btnMACAddress.ClientID%>").click(function (e) {

                try {
                    var ActiveXobj = new ActiveXObject("WbemScripting.SWbemLocator");
                    var Con = ActiveXobj.ConnectServer(".");

                    var Query = Con.ExecQuery("SELECT * FROM Win32_NetworkAdapterConfiguration");
                    var eResult = new Enumerator(Query);

                    var Table = $("<Table border='2' cellPadding='3px' cellSpacing='1px' bgColor='#CCCCCC'></Table>").append("<Tr  bgColor='#EAEAEA'><Td>Caption</Td><Td>MAC</Td></Tr>");
                  
                    while (!eResult.atEnd()) {

                        eResult.moveNext();

                        var Data = eResult.item();

                        if (Data != null) {

                            Table.append("<Tr bgColor='#FFFFFF'><Td>"+Data.Caption+"</Td><Td>"+Data.MACAddress+"</Td></Tr>");
                        }
                    }

                    $("#GetMAC").html(Table);

                    e.preventDefault();
                }
                catch (ex) {
                    alert(ex.message);
                }

            });

    }); 

</script>
</head>
<body>
    <form id="form1" runat="server">   
    <div>
   
  <asp:Button ID="btnMACAddress" runat="server" Text="Get MAC Address" />
      <div id="GetMAC"></div>

      
        </div>	
    </form>
</body>
</html>
