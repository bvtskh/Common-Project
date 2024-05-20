namespace CommonProject.Loading
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;
    using System.ComponentModel;
    using System.Data;
    using CommonProject.Entities;
    using CommonProject.Business;

    namespace LoadingClass
    {
        public class BackgroundLoading
        {
            public delegate DataTable RunFunction();
            public delegate void FinishFunction(DataTable dt);
            public BackgroundWorker Bw;
            public RunFunction thisFunction;
            public FinishFunction finishFunction;
            LoadingForm newLoading;

            public static void PerformTask<T>(Action<T> task, T parameter)
            {
                LoadingForm loadingForm = new LoadingForm();
                Thread thread = new Thread(new ThreadStart(() =>
                {
                    task(parameter);
                    CloseLoadingForm(loadingForm);
                }));

                thread.Start();
                loadingForm.ShowDialog();
            }
            private static void CloseLoadingForm(LoadingForm loadingForm)
            {
                if (loadingForm != null && !loadingForm.IsDisposed)
                {
                    loadingForm.Invoke((MethodInvoker)delegate
                    {
                        loadingForm.Close();
                    });
                }
            }


            public BackgroundLoading()
            {

            }
            public BackgroundLoading(RunFunction newFunction, FinishFunction finishFunction)
            {
                thisFunction = newFunction;
                this.finishFunction = finishFunction;
                Bw = new BackgroundWorker();
                Bw.WorkerReportsProgress = true;
                Bw.DoWork += new DoWorkEventHandler(Bw_DoWork);
                Bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Bw_RunWorkerCompleted);
                Bw.ProgressChanged += new ProgressChangedEventHandler(Bw_ReportProgress);
            }

            private void Bw_ReportProgress(object sender, System.ComponentModel.ProgressChangedEventArgs e)
            {
                var i = e.ProgressPercentage;
                if (i == ERROR_ID.ERROR_GETDATA_NULL)
                {
                    newLoading.Dispose();
                    MessageBox.Show(e.UserState as String, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            public void Start(bool isShowLoading = true)
            {
                Bw.RunWorkerAsync();
                newLoading = new LoadingForm();
                if (isShowLoading)
                {
                    newLoading.ShowDialog();
                }
            }

            void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                if (finishFunction != null && e.Result != null)
                {
                    finishFunction((DataTable)e.Result);
                }

                newLoading.Dispose();
            }

            void Bw_DoWork(object sender, DoWorkEventArgs e)
            {
                try
                {
                    if (thisFunction != null)
                        e.Result = thisFunction();
                }
                catch (Exception ex)
                {
                    Bw.ReportProgress(ERROR_ID.ERROR_GETDATA_NULL, ex.Message.ToString());
                }

            }
        }
    }

}
