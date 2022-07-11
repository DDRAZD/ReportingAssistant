Assignment in Udemy MVC project

Used the following packages in Nuget package manager to set up:

Install-Package bootstrap -Version 5.2.0-beta1

Install-Package Font.Awesome -Version 5.15.4

Install-Package jQuery -Version 3.6.0

Install-Package popper.js -Version 1.16.1


install-package EntityFrameWork
----------------------------------------------------------------------------------------------

Building the scaffolding first with basic layout pages and identity management
------------------------------------------------------------------------------

for identity management, added this:

Install-Package Microsoft.AspNet.Identity.EntityFramework -Version 2.2.3

Install-Package Microsoft.AspNet.Identity.Owin

Install-Package Microsoft.Owin.Host.SystemWeb

created a connection string in web.config


After that, you are required to createa an OWIN Startup class:
* on prject level, create Startup.cs -> "add new item"
go to "web"
select "OWIN Statup class"


Then, the OWIN startup file, import: 
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity.EntityFramework;

then add a statement to use Cookie Authenticaion:

app.UseCookieAuthentication(new CookieAuthenticationOptions() { AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie, LoginPath=new PathString("/Account/Login") });





-- afterwards,

Enable-Migrations -ContextTypeName ReportingAssistant.Identity.ApplicationDbContext -MigrationsDirectory IdentityMigrations
             
             
 Add-Migration -Configuration ReportingAssistant.IdentityMigrations.Configuration Initial(this is an arbitrary name)
            then
 update-database -Configuration ReportingAssistant.IdentityMigrations.Configuration


 ------------------------------------------------------



Assignment description:
Requirement:

Create an asp.net mvc app, called "Reporting Assistant", for "Task Assignment and tracking the progress of task".

The company has two types of users:  "User" and "Admin".

The admin user assigns one or more tasks to the user everyday.

The users can see the tasks assigned to them [from different admins] and start doing those tasks. [It will be stored in "Tasks" table]

At the end of day, the user can add the information about the tasks he has done during the day. [It will be stored in "TasksDone" table]

At the end of same day or next day morning, the admin user will re-check the tasks completed by the user and add his comments about the pending work, bugs, issues, approvals or any other comments. [It will be stored in "FinalComments" table]

The user will check the "FinalComments" in the next day and do work through the day and add the details of tasks completed to "TasksDone" table.



Any admin can add tasks to any user.

So the user may get tasks from different admins; multiple tasks from the same admin also.

All tasks done by all users, are visible to all admins.

Any admin can add comments etc., to any task done by any user [will be stored in "finalcomments" table].



The user can edit "tasks done" details of the same user.

The admin can edit "tasks" and "final comments" of the same admin; but can view all "tasks", "tasks done" and "final comments" of all users and all admins.

No one can assign tasks to "admin" users.

One person can play role of "user" and "admin", at-a-time; then other admins can assigns tasks to him, as he plays a role of "User".



Each "task", "task done" and "final comment", have an option of attachment [image].



Roles:

1. "User" role

      By default, it must have three users: "nuzhath", "harsha", "nazareen".

2. "Admin" role
      By default, it must have three admins:  "harsha", "shylender", "harika".

Note:  "harsha" is single person; but plays the role of "Admin" and "User".



Tables:

1. "Categories" table:

   CategoryID: long, primary key, not null, unique, auto-generated.

   CategoryName: string, allow alphabets, digits and spaces only, not null, unique.

2. "Projects" table:

   ProjectID: long, primary key, not null, unique, auto-generated

   ProjectName: string, allow alphabets, digits and spaces only, not null, unique

   DateOfStart: datetime, allow null

   AvailabilityStatus: Only two options: "Available" and "Not Available"; radio button

   CategoryID: Foreign key from "Categories" table, shown as dropdownlist; not null

   Photo: Allow file uploading; store image in some folder and store the image path in this column; allow null.

3. "Tasks" table:

   TaskID: long, primary key, not null, unique, auto-generated

   Screen: string, min 2 characters length, max 50 characters.

   Description: string, min 2 characters length, max 10000 characters.

   AdminUserID: long, Foreign key from "AspNetUsers" table of Asp.Net Identity; not null

   UserID: long, Foreign Key from "AspNetUsers" table of Asp.Net Identity; not null

   DateOfTask: datetime, not null

   Attachment:  Allow file uploading; store image in some folder and store the image path in this column; allow null.

   ProjectID: Foreign Key from "Projects" table

4. "TasksDone" table:

   TaskDoneID: long, primary key, not null, unique, auto-generated

   Screen: string, min 2 characters length, max 50 characters.

   Description: string, min 2 characters length, max 10000 characters.

   UserID: long, Foreign Key from "AspNetUsers" table of Asp.Net Identity; not null

   DateOfTaskDone: datetime, not null

   Attachment:  Allow file uploading; store image in some folder and store the image path in this column; allow null.

   ProjectID: Foreign Key from "Projects" table

5. "FinalComments" table:

   FinalCommentID: long, primary key, not null, unique, auto-generated

   Screen: string, min 2 characters length, max 50 characters.

   Description: string, min 2 characters length, max 10000 characters.

   AdminUserID: long, Foreign key from "AspNetUsers" table of Asp.Net Identity; not null

   UserID: long, Foreign Key from "AspNetUsers" table of Asp.Net Identity; not null

   DateOfFinalComment: datetime, not null

   Attachment:  Allow file uploading; store image in some folder and store the image path in this column; allow null.

   ProjectID: Foreign Key from "Projects" table




   Additional Instructions:

Use HTML helpers

Use Entity Framework Code First Approach with Code-First Migrations

Use Strongly-Typed Views

Use AntiForgeryToken

Use Razor View Engine

Use Layout view for "User" and another Layout view for "Admin"; with _ViewStart.cshtml for each.

Use Sorting, Paging with EF in Categories and Project pages.

Create necessary validations as explained above.

Use asp.net identity for registration, login, my profile, change password etc., pages.

Create roles: "Admin" and "User" in Startup.cs file

Create sample admins and users as specified above in Startup.cs file.

There is no registration page for admin; admin can be created only through "Startup.cs" file.

Use IAuthorizationFilter and IAuthenticationFilter

Use Exception Handling using Custom Errors, IExceptionFilter

Use Service Pattern along with Repository Pattern

Use jQuery Validation Plugin, Bootstrap and Font-Awesome.