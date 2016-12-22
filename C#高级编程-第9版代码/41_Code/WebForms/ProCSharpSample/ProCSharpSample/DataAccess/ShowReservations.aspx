<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowReservations.aspx.cs" Inherits="ProCSharpSample.DataAccess.ShowReservations" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource1" DataTextField="RoomName" DataValueField="Id" Height="22px" Width="150px">
        </asp:DropDownList>
        <br />
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetMeetingRooms" TypeName="ProCSharpSample.DataAccess.RoomReservationRepository"></asp:ObjectDataSource>
        <br />
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" DataObjectTypeName="ProCSharpSample.Models.Reservation" DeleteMethod="DeleteReservation" InsertMethod="DeleteReservation" SelectMethod="GetReservationsByRoom" TypeName="ProCSharpSample.DataAccess.RoomReservationRepository" UpdateMethod="UpdateReservation">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="roomId" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <br />
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="ObjectDataSource2">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" ReadOnly="True" />
                <asp:TemplateField HeaderText="Contact" SortExpression="Contact">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Contact") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Contact") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ReservationFrom" HeaderText="From" SortExpression="ReservationFrom" />
                <asp:BoundField DataField="ReservationTo" HeaderText="To" SortExpression="ReservationTo" />
                <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="MeetingRoom" SortExpression="MeetingRoom">
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="ObjectDataSource1" DataTextField="RoomName" DataValueField="Id" Height="25px" SelectedValue='<%# Bind("RoomId") %>' Width="162px">
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("MeetingRoom.RoomName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
    
    </div>
    </form>
</body>
</html>
