[HttpClient.Compression 1.0 Beta](http://github.com/AdvancedREI/HttpClient.Compression)
=================

HttpClient.Compression is a Portable Class Library for using GZIP and DEFLATE compression in conjunction with Microsoft's new PCL version of the HttpClient. It is based on a [Gist created by Morten Nielsen](https://gist.github.com/dotMorten/4981198), but runs on all platforms.

Works on .NET 4.0, 4.0.3, & 4.5, Silverlight 4 & 5, Windows Phone 7.5 & 8, and Windows 8.

Quick start
-----------

Install the NuGet package: `Install-Package HttpClient.Compression -Pre`, clone the repo, `git clone git://github.com/advancedrei/HttpClient.Compression.git`, or [download the latest release](https://github.com/advancedrei/HttpClient.Compression/zipball/master).

To use in your code, create a new instance of the CompressedHttpClientHandler, and pass it into the HttpClient, as shown below.

        var handler = new CompressedHttpClientHandler();
        var client = new HttpClient(handler);
        var result = await client.GetStringAsync("https://nuget.org/api/v2/Packages()?$filter=tolower(Id)%20eq%20'microsoft.bcl.async'&$orderby=Id&$skip=0&$top=30");

You can verify that the payload was compressed using Fiddler.

Bug tracker
-----------

Have a bug? Please create an issue here on GitHub that conforms with [necolas's guidelines](https://github.com/necolas/issue-guidelines).

https://github.com/AdvancedREI/HttpClient.Compression/issues



Twitter account
---------------

Keep up to date on announcements and more by following AdvancedREI on Twitter, [@AdvancedREI](http://twitter.com/AdvancedREI).



Blog
----

Read more detailed announcements, discussions, and more on [The AdvancedREI Dev Blog](http://advancedrei.com/blogs/development).


Author
-------

**Robert McLaws**

+ http://twitter.com/robertmclaws
+ http://github.com/advancedrei


Copyright and license
---------------------

Copyright 2013 AdvancedREI, LLC.

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this work except in compliance with the License. You may obtain a copy of the License in the LICENSE file, or at:

   http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and limitations under the License.
