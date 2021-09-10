# Nx Identity provider
1) Install: dotnet new -i IdentityServer4.Templates
-- after that start with empty template : dotnet new is4empty -n Marvin.IDP
-- then in VS add newly created project to solution

2) Open new projects properties debug:
enable SSL and run as Launch: Project 
uncheck launch browser 

!!! /.well-known/openid-configuration  
--- you can see config here !!!

3) Ading Identity Server quickstartUI
dotnet new is4ui
-- then in startup.cs uncomment services.AddControllersWithViews(), UseStaticFiles(), UseRouting(), UseEndpoints()

4) using Authorization Code Flow + PKCE
- client issues code_challenge -> IDP provider returns id_token and access_token
- client sends access_token to API


5) Authorization policies:
Role Based Access Control VS Attriute based ABAC
- both are based on claims
1st i simple e.g. "payingUser"   other is more complex combination of cloaims 
and is preffered to avoid clreating too much roles
e.g. specific supscription and country : belgium