<%@ Control Inherits="ViewUserControl<Player>" %>

<%: Html.HiddenFor(m => m.Id) %>
<%: Html.TextBoxFor(m => m.PlayerName) %>
