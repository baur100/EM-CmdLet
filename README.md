# EM-CmdLet
<h2>Assignment:</h2>
<ul>
<li>User has fields: Name, Address, Email from input and ID - auto by program</li>
<li>Users stores in XML file</li>
<li>I need to implement next commands:</li>
<ul>
<li><b>C</b>reateUser</li>
<li><b>R</b>eportUser - Get List of all users</li>
<li><b>U</b>pdateUser - (Inconsistent fields)</li>
<li><b>D</b>eleteUser</li>
<li>Check for consistency (Address and Email field could be empty - That fields must be eliminated)<li>
</ul>
</ul>
<p>
<h2>How to:</h2>
<ul>
<li>Download CmdLet.dll to Downloads folder</li>
<li>Run PowerShell</li>
<li>Use <code>Import-Module %USERPROFILE%\Downloads\CmdLet.dll </code> to import cmdlet</li>
<li>Use <code>Get-Command -module CmdLet</code> to get Command list</li>
<li>Get Help using <code>Get-Help</code></li>
<li>First, you need to create XML file using <code>New-File</code> (File test-em.xml will be created at %USERPROFILE%\ folder)</li>
<li>Use <code>Add-User</code> to add users (Name field could not be empty)</li>
<li>Use <code>Get-List</code> to get user list</li>
<li>Use <code>Remove-User</code> to Remove user by ID</li>
<li>Use <code>Get-Update</code> to update user's address and email by ID</li>
<li>Use <code>Get-Check</code> to check users for empty address and email field</li>
<li>Have a fun)))</li>
</ul>
