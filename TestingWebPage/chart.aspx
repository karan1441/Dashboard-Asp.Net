<%@ Page Language="C#" AutoEventWireup="true" CodeFile="chart.aspx.cs" Inherits="chart" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html><html xmlns="http://www.w3.org/1999/xhtml"><head runat="server"><title></title></head><body><form id="form1" runat="server">
    <div>
    
    </div> 
        <asp:Chart ID="Chart1" runat="server" Height="412px" Width="860px" >
            <series>
                <asp:Series Name="Series1" XValueMember="speed">
                </asp:Series>
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </chartareas>
        </asp:Chart>
    
    <div>
             <asp:DropDownList ID="DropDownList1" runat="server" Height="90px" style="margin-bottom: 0px" Width="218px" AutoPostBack="TRUE">
        </asp:DropDownList>
            
            <asp:DropDownList ID="DropDownList2" runat="server" Height="90px" style="margin-bottom: 0px" Width="218px"> 
        
        </asp:DropDownList>

        </div>
        <asp:Button ID="Button1" runat="server" Text="Button" Height="179px" style="margin-right: 0px" Width="673px" />
        <div id="chartContainer" style="height: 370px; width:100%;"></div>
<script src="canvas.js"></script><script src="JavaScript.js"></script>
    </form>

</body>
</html>
