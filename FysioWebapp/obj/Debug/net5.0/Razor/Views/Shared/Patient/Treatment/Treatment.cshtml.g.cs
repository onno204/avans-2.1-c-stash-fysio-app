#pragma checksum "C:\Users\onnov\Documents\AA_Sorted\Git\avans-2.1-c-stash-fysio-app\FysioWebapp\Views\Shared\Patient\Treatment\Treatment.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "426104eb2336169f5d1b647e544fc3a780f5343d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Patient_Treatment_Treatment), @"mvc.1.0.view", @"/Views/Shared/Patient/Treatment/Treatment.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\onnov\Documents\AA_Sorted\Git\avans-2.1-c-stash-fysio-app\FysioWebapp\Views\_ViewImports.cshtml"
using FysioWebapp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\onnov\Documents\AA_Sorted\Git\avans-2.1-c-stash-fysio-app\FysioWebapp\Views\_ViewImports.cshtml"
using FysioWebapp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"426104eb2336169f5d1b647e544fc3a780f5343d", @"/Views/Shared/Patient/Treatment/Treatment.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e933f14ea119bc4a5b8c26015092db9c27b754f8", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Patient_Treatment_Treatment : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\onnov\Documents\AA_Sorted\Git\avans-2.1-c-stash-fysio-app\FysioWebapp\Views\Shared\Patient\Treatment\Treatment.cshtml"
  
    ViewData["Title"] = "Behandeldossier";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""row new-patient"">
    <div class=""col-md-3"">
        <h3>Persoonsgegevens</h3>
        <div class=""form-group"">
            <label for=""full-name"">Volledige naam</label>
            <input type=""text"" class=""form-control"" id=""full-name"" placeholder=""Onno van Helfteren"" disabled>
        </div>
        <div class=""form-group"">
            <label for=""email"">E-mailadres</label>
            <input type=""email"" class=""form-control"" id=""email"" placeholder=""onno@fysioapp.com"" disabled>
        </div>
        <div class=""form-group"">
            <label for=""birthdate"">Geboortedatum</label>
            <input type=""date"" class=""form-control"" id=""birthdate"" disabled>
        </div>
        <div class=""form-group"">
            <label for=""employee-or-student"">Medewerker of student?</label>
            <select class=""form-control"" id=""employee-or-student"" disabled>
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "426104eb2336169f5d1b647e544fc3a780f5343d4471", async() => {
                WriteLiteral("Medewerker");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </select>
            <input type=""number"" class=""form-control"" id=""studentnumber"" placeholder=""Student-/medewerkernummer"" value=""2167988"" disabled>
        </div>
    </div>
    <div class=""col-md-3"">
        <h3>Behandel gegevens</h3>
        <div class=""form-group"">
            <label for=""global-description-complaints"">Globale klachten omschrijving</label>
            <textarea class=""form-control"" id=""global-description-complaints"" rows=""3"" disabled></textarea>
        </div>
        <div class=""form-group"">
            <label for=""diagnosticscode"">Diagnosecode</label>
            <select class=""form-control"" id=""diagnosticscode"" disabled>
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "426104eb2336169f5d1b647e544fc3a780f5343d6156", async() => {
                WriteLiteral("2500 [Inwendige organen thorax] Amputatie");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </select>
            <input type=""text"" disabled class=""form-control"" id=""diagnostics-description"" placeholder=""Omschrijving"" value=""Amputatie"" disabled>
        </div>
        <div class=""form-group"">
            <label for=""enddate-treatment"">Einddatum behandeling</label>
            <input type=""date"" class=""form-control"" id=""enddate-treatment"" disabled>
        </div>
        <br />
    </div>
    <div class=""col-md-6"" style=""max-height: 50vh"">
        <h3>Bezoek geschiedenis</h3>
        <table class=""table table-max-height-1"">
            <thead>
                <tr>
                    <th scope=""col"">Datum</th>
                    <th scope=""col"">Start tijd</th>
                    <th scope=""col"">Eind tijd</th>
                    <th scope=""col"">Behandelaar</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <th scope=""row"">01-10-2021</th>
                    <td>10.00u</td>
                    <td>11.00u");
            WriteLiteral(@"</td>
                    <td>onno@fysioapp.com</td>
                </tr>
                <tr>
                    <th scope=""row"">01-10-2021</th>
                    <td>10.00u</td>
                    <td>11.00u</td>
                    <td>onno@fysioapp.com</td>
                </tr>
                <tr>
                    <th scope=""row"">01-10-2021</th>
                    <td>10.00u</td>
                    <td>11.00u</td>
                    <td>onno@fysioapp.com</td>
                </tr>
                <tr>
                    <th scope=""row"">01-10-2021</th>
                    <td>10.00u</td>
                    <td>11.00u</td>
                    <td>onno@fysioapp.com</td>
                </tr>
                <tr>
                    <th scope=""row"">01-10-2021</th>
                    <td>10.00u</td>
                    <td>11.00u</td>
                    <td>onno@fysioapp.com</td>
                </tr>
                <tr>
                    <th scope=""row"">01-10-20");
            WriteLiteral(@"21</th>
                    <td>10.00u</td>
                    <td>11.00u</td>
                    <td>onno@fysioapp.com</td>
                </tr>
                <tr>
                    <th scope=""row"">01-10-2021</th>
                    <td>10.00u</td>
                    <td>11.00u</td>
                    <td>onno@fysioapp.com</td>
                </tr>
                <tr>
                    <th scope=""row"">01-10-2021</th>
                    <td>10.00u</td>
                    <td>11.00u</td>
                    <td>onno@fysioapp.com</td>
                </tr>
                <tr>
                    <th scope=""row"">01-10-2021</th>
                    <td>10.00u</td>
                    <td>11.00u</td>
                    <td>onno@fysioapp.com</td>
                </tr>
                <tr>
                    <th scope=""row"">01-10-2021</th>
                    <td>10.00u</td>
                    <td>11.00u</td>
                    <td>onno@fysioapp.com</td>
             ");
            WriteLiteral(@"   </tr>
            </tbody>
        </table>
        <h3>Opmerking geschiedenis</h3>
        <table class=""table table-max-height-1"">
            <thead>
                <tr>
                    <th scope=""col"">Datum</th>
                    <th scope=""col"">Opmerking</th>
                    <th scope=""col"">Door</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <th scope=""row"">01-10-2021 11:32</th>
                    <td>Hij heeft overgewicht</td>
                    <td>onno@fysioapp.com</td>
                </tr>
                <tr>
                    <th scope=""row"">01-10-2021 11:32</th>
                    <td>Hij heeft overgewicht</td>
                    <td>onno@fysioapp.com</td>
                </tr>
                <tr>
                    <th scope=""row"">01-10-2021 11:32</th>
                    <td>Hij heeft overgewicht</td>
                    <td>onno@fysioapp.com</td>
                </tr>
               ");
            WriteLiteral(@" <tr>
                    <th scope=""row"">01-10-2021 11:32</th>
                    <td>Hij heeft overgewicht</td>
                    <td>onno@fysioapp.com</td>
                </tr>
                <tr>
                    <th scope=""row"">01-10-2021 11:32</th>
                    <td>Hij heeft overgewicht</td>
                    <td>onno@fysioapp.com</td>
                </tr>
                <tr>
                    <th scope=""row"">01-10-2021 11:32</th>
                    <td>Hij heeft overgewicht</td>
                    <td>onno@fysioapp.com</td>
                </tr>
            </tbody>
        </table>
    </div>
    <div style=""margin-top: 1rem;"" class=""col-md-3"">
        <h3>Administratie gegevens</h3>
        <div class=""form-group"">
            <label for=""intake-by"">Intake gedaan door</label>
            <select class=""form-control"" id=""intake-by"" disabled>
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "426104eb2336169f5d1b647e544fc3a780f5343d12380", async() => {
                WriteLiteral("onno@fysioapp.com");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </select>\r\n        </div>\r\n        <div class=\"form-group\">\r\n            <label for=\"intake-supervision\">Intake onder supervisie van</label>\r\n            <select class=\"form-control\" id=\"intake-supervision\" disabled>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "426104eb2336169f5d1b647e544fc3a780f5343d13614", async() => {
                WriteLiteral("sylvester@fysioapp.com");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </select>\r\n        </div>\r\n        <div class=\"form-group\">\r\n            <label for=\"main-therapist\">Hoofdbehandelaar</label>\r\n            <select class=\"form-control\" id=\"main-therapist\" disabled>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "426104eb2336169f5d1b647e544fc3a780f5343d14834", async() => {
                WriteLiteral("onno@fysioapp.com");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </select>
        </div>
        <div class=""form-group"">
            <label for=""signup-date"">Aanmeld datum</label>
            <input type=""date"" class=""form-control"" id=""signup-date"" disabled>
        </div>
    </div>
    <div class=""col-md-9 mt-3"">
        <h3>Behandel geschiedenis</h3>
        <table class=""table table-max-height-2"">
            <thead>
                <tr>
                    <th scope=""col"">Datum</th>
                    <th scope=""col"">Door</th>
                    <th scope=""col"">Type</th>
                    <th scope=""col"">Omschrijving</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <th scope=""row"">01-10-2021 11:32</th>
                    <td>onno@fysioapp.com</td>
                    <td>1100</td>
                    <td>Individuele zitting kinderfysiotherapie</td>
                </tr>
                <tr>
                    <th scope=""row"">01-10-2021 11:32</th>
              ");
            WriteLiteral(@"      <td>onno@fysioapp.com</td>
                    <td>1100</td>
                    <td>Individuele zitting kinderfysiotherapie</td>
                </tr>
                <tr>
                    <th scope=""row"">01-10-2021 11:32</th>
                    <td>onno@fysioapp.com</td>
                    <td>1100</td>
                    <td>Individuele zitting kinderfysiotherapie</td>
                </tr>
                <tr>
                    <th scope=""row"">01-10-2021 11:32</th>
                    <td>onno@fysioapp.com</td>
                    <td>1100</td>
                    <td>Individuele zitting kinderfysiotherapie</td>
                </tr>
                <tr>
                    <th scope=""row"">01-10-2021 11:32</th>
                    <td>onno@fysioapp.com</td>
                    <td>1100</td>
                    <td>Individuele zitting kinderfysiotherapie</td>
                </tr>
                <tr>
                    <th scope=""row"">01-10-2021 11:32</th>
          ");
            WriteLiteral(@"          <td>onno@fysioapp.com</td>
                    <td>1100</td>
                    <td>Individuele zitting kinderfysiotherapie</td>
                </tr>
                <tr>
                    <th scope=""row"">01-10-2021 11:32</th>
                    <td>onno@fysioapp.com</td>
                    <td>1100</td>
                    <td>Individuele zitting kinderfysiotherapie</td>
                </tr>
            </tbody>
        </table>
    </div>
</div>
");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591