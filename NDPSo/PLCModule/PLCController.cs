using NDPSo.Utils;
using S7.Net;
using S7.Net.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NDPSo.PLCModule
{
    public class PLCController
    {
        private Plc _plc;
        private int mutexTime = 500;
        private int retryEventReleaseNum = 5;
        private int maxNumberErrorAccepted = 10;
        private int numberError;
        private static AutoResetEvent _event = new AutoResetEvent(false);
        private bool isReconnecting = false;
        public PLCController() => this.Init();

        public void Init()
        {
            this._plc = new Plc(CpuType.S71200, ConfigManager.TramTronConfig.LANIP, 0, 1);
            try
            {
                this._plc.Open();
            }
            catch (System.Exception ex)
            {
                TramTronLogger.WriteError(ex);
            }
        }

        public async Task ReConnectAsync()
        {
            /*await Task.Run(() =>
            {
                try
                {
                    this._plc = new Plc(CpuType.S71200, ConfigManager.TramTronConfig.LANIP, 0, 1);
                    this._plc.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred while trying to reconnect to the PLC: " + ex.Message);
                }
            });*/
            await Task.Factory.StartNew(async () =>
            {
                this._plc = new Plc(CpuType.S71200, ConfigManager.TramTronConfig.LANIP, 0, 1);
                try
                {
                    this._plc.OpenAsync();
                }
                catch (Exception ex)
                {
                    TramTronLogger.WriteError(ex);
                }
            });
        }
        public async void AttemptReconnect()
        {
            if (!isReconnecting)
            {
                isReconnecting = true;
                try
                {
                    await ReConnectAsync();

                }
                finally
                {
                    isReconnecting = false;
                }
            }
        }
        public bool IsConnected
        {
            get => this._plc.IsConnected;
        }


        private void RetryEventRelease()
        {
            for (int index = 0; index < this.retryEventReleaseNum; ++index)
            {
                try
                {
                    PLCController._event.Set();
                    break;
                }
                catch (Exception ex)
                {
                    TramTronLogger.WriteError(ex);
                }
            }
        }

        private void HandleException()
        {
            ++this.numberError;
            if (this.numberError != this.maxNumberErrorAccepted)
                return;
            this.numberError = 0;
            if (this._plc != null)
                this._plc.Close();
            this.Init();
        }

        public void WriteStruct(object structValue, int DB, int startByteAddr)
        {
            try
            {
                PLCController._event.WaitOne(this.mutexTime);
                byte[] bytes = Struct.ToBytes(structValue);
                this.WriteBytes(S7.Net.DataType.DataBlock, DB, startByteAddr, bytes);
            }
            catch (System.Exception ex)
            {
                this.HandleException();
            }
            finally
            {
                this.RetryEventRelease();
            }
        }

        public void WriteBytes(S7.Net.DataType DataType, int DB, int StartByteAdr, byte[] value)
        {
            try
            {
                PLCController._event.WaitOne(this.mutexTime);
                this._plc.WriteBytes(DataType, DB, StartByteAdr, value);
            }
            catch (System.Exception ex)
            {
                this.HandleException();
            }
            finally
            {
                this.RetryEventRelease();
            }
        }

        public byte[] ReadBytes(S7.Net.DataType DataType, int DB, int StartByteAdr, int count)
        {
            byte[] numArray = new byte[300];
            try
            {
                PLCController._event.WaitOne(this.mutexTime);
                numArray = this._plc.ReadBytes(DataType, DB, StartByteAdr, count);
            }
            catch (System.Exception ex)
            {
                this.HandleException();
            }
            finally
            {
                this.RetryEventRelease();
            }
            return numArray;
        }

        public void WriteBit(S7.Net.DataType DataType, int DB, int StartByteAdr, int BitAdr, bool value)
        {
            try
            {
                PLCController._event.WaitOne(this.mutexTime);
                this._plc.WriteBit(DataType, DB, StartByteAdr, BitAdr, value);
            }
            catch (System.Exception ex)
            {
                this.HandleException();
            }
            finally
            {
                this.RetryEventRelease();
            }
        }

        public string CheckConnection()
        {
            string empty = string.Empty;
            return !this._plc.IsConnected ? "not connected" : empty;
        }
    }
}
