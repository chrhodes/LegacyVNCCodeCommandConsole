using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;

using VNC;

namespace VNCCodeCommandConsole.User_Interface.User_Controls
{
    public partial class wucCommandsDesign : wucDXBase
    {
        private static int CLASS_BASE_ERRORNUMBER = ErrorNumbers.APPERROR;
        private const string LOG_APPNAME = Common.LOG_APPNAME;

        #region Constructors

        public wucCommandsDesign()
        {
#if TRACE
            long startTicks = Log.Trace15("Enter", LOG_APPNAME);
#endif
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show(ex.InnerException.ToString());
            }
#if TRACE
            Log.Trace15("End", LOG_APPNAME, startTicks);
#endif
        }

        #endregion

        //public wucCodeExplorer CodeExplorer = null;
        //public wucCodeExplorerContext CodeExplorerContext = null;

        #region Initialization

        internal override void OnLoaded(object sender, RoutedEventArgs e)
        {
#if TRACE
            long startTicks = Log.Trace15("Enter", LOG_APPNAME);
#endif
            // Cheat and force outcome if not using dat
            Common.DataFullyLoaded = true;
            User_Interface.Helper.ValidateDataFullyLoaded();

            try
            {
                if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
                {
                    //dataGrid.ItemsSource = VNCWPFUserControls.Common.ApplicationDataSet.ApplicationUsage;
                }

                //ViewMode.ApplyAuthorization(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
#if TRACE
            Log.Trace15("End", LOG_APPNAME, startTicks);
#endif
        }

        #endregion

        #region Event Handlers

        private void OnCustomColumnDisplayText(object sender, DevExpress.Xpf.Grid.CustomColumnDisplayTextEventArgs e)
        {
            //CustomFormat.FormatStorageColumns(e);
        }

        #endregion

        private void CustomUnboundColumnData(object sender, DevExpress.Xpf.Grid.GridColumnDataEventArgs e)
        {
            //UnboundColumns.GetEnvironmentInstanceDatabaseColumns(e);
        }

        #region Main Function Routines



        #endregion

        private void btnCallTagTarget(object sender, RoutedEventArgs e)
        {
            string targetName = ((Button)sender).Tag.ToString();
            string language = lbeCommandsDesign_Language.EditValue.ToString();

            //Boolean includeTrivia = ceStructuresIncludeTrivia.IsChecked.Value;
            //Boolean statementsOnly = ceStructuresStatementsOnly.IsChecked.Value;

            StringBuilder sb = new StringBuilder();

            var sourceCode = "";

            using (var sr = new StreamReader(CodeExplorerContext.teSourceFile.Text))
            {
                sourceCode = sr.ReadToEnd();
            }

            string metricClass = $"VNC.CodeAnalysis.DesignMetrics.{language}.{targetName},VNC.CodeAnalysis";

            Type metricType = Type.GetType(metricClass);
            MethodInfo metricMethod = metricType.GetMethod("Check");
            object[] parametersArray = new object[] { sourceCode };

            sb = (StringBuilder)metricMethod.Invoke(null, parametersArray);

            CodeExplorer.teSourceCode.Text = sb.ToString();
        }
    }
}
