using Otel_Otomasyon.Helper.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel_Otomasyon.Helper
{
    public class OtelRepository : Repository<Otel>, IDisposable
    {

        public OtelRepository()
        {
            _connectionString = DBHelper.GetConnectionString();
            _dbProviderName = DBHelper.GetConnectionProvider();
            _dbProviderFactory = DbProviderFactories.GetFactory(_dbProviderName);
        }

        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool bDisposing)
        {
            // Check the Dispose method called before.
            if (!_bDisposed)
            {
                if (bDisposing)
                {
                    // Clean the resources used.
                    _dbProviderFactory = null;
                }

                _bDisposed = true;
            }
        }


        public void OtelSil(Otel otel)
        {
            try
            {
                bool isSuccess;
                
                    isSuccess = DeletedById(otel.otelID);
                
                if (isSuccess)
                    System.Windows.Forms.MessageBox.Show("Başarıyla Silindi");
                else
                    System.Windows.Forms.MessageBox.Show("Silerken Hata Oluştu");

            }
            catch (Exception ex)
            {
                throw new Exception("OtelRepository::Hata Oluştu.", ex);
            }

        }


        public override bool DeletedById(object id)
        {
            _errorCode = 0;
            _rowsAffected = 0;

            try
            {
                var query = new StringBuilder();
                query.Append("DELETE ");
                query.Append("FROM [dbo].[tblOtel] ");
                query.Append("WHERE ");
                query.Append("[otelID] = @id ");
                query.Append("SELECT @intErrorCode=@@ERROR; ");

                var commandText = query.ToString();
                query.Clear();

                using (var dbConnection = _dbProviderFactory.CreateConnection())
                {
                    if (dbConnection == null)
                        throw new ArgumentNullException("dbConnection", "The db connection can't be null.");

                    dbConnection.ConnectionString = _connectionString;

                    using (var dbCommand = _dbProviderFactory.CreateCommand())
                    {
                        if (dbCommand == null)
                            throw new ArgumentNullException(
                                "dbCommand" + " The db SelectById command for entity [Otel] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        //Input Parameters
                        DBHelper.AddParameter(dbCommand, "@id", CsType.Int, ParameterDirection.Input, id);

                        //Output Parameters
                        DBHelper.AddParameter(dbCommand, "@intErrorCode", CsType.Int, ParameterDirection.Output, null);

                        //Open Connection
                        if (dbConnection.State != ConnectionState.Open)
                            dbConnection.Open();
                        //Execute query
                        _rowsAffected = dbCommand.ExecuteNonQuery();
                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());

                        if (_errorCode != 0)
                            throw new Exception(
                                "Deleting Error for entity [Otel] reported the Database ErrorCode: " + _errorCode);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("OtelRepository::Insert:Error occured.", ex);
            }
        }

        public void OtelEkle(Otel otel)
        {
            try
            {
                bool isSuccess;

                    isSuccess = Insert(otel);

                if (isSuccess)
                    System.Windows.Forms.MessageBox.Show("Başarıyla Eklendi");
                else
                    System.Windows.Forms.MessageBox.Show("Eklerken Hata Oluştu");
            }
            catch (Exception ex)
            {
                throw new Exception("OtelRepository::Hata Oluştu.", ex);
            }
        }


        public override bool Insert(Otel entity)
        {
            _rowsAffected = 0;
            _errorCode = 0;

            try
            {
                var query = new StringBuilder();
                query.Append("INSERT [dbo].[tblOtel] ");
                query.Append(" ( [adi], [il], [ilce], [adres], [telefon], [ePosta], [yildizSayisi], [odaSayisi], [odaTipi], [otelPuani], [oySayisi] ) ");
                query.Append("VALUES ");
                query.Append(
                    "( @adi, @il, @ilce, @adres, @telefon, @ePosta, @yildizSayisi, @odaSayisi, @odaTipi, @otelPuani, @oySayisi ) ");
                query.Append("SELECT @intErrorCode=@@ERROR;");

                var commandText = query.ToString();
                query.Clear();

                using (var dbConnection = _dbProviderFactory.CreateConnection())
                {
                    if (dbConnection == null)
                        throw new ArgumentNullException("dbConnection", "The db connection can't be null.");

                    dbConnection.ConnectionString = _connectionString;

                    using (var dbCommand = _dbProviderFactory.CreateCommand())
                    {
                        if (dbCommand == null)
                            throw new ArgumentNullException("dbCommand" + " The db Insert command for entity [Otel] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        //Input Params
                        DBHelper.AddParameter(dbCommand, "@adi", CsType.String, ParameterDirection.Input, entity.adi);
                        DBHelper.AddParameter(dbCommand, "@il", CsType.String, ParameterDirection.Input, entity.il);
                        DBHelper.AddParameter(dbCommand, "@ilce", CsType.String, ParameterDirection.Input, entity.ilce);
                        DBHelper.AddParameter(dbCommand, "@adres", CsType.String, ParameterDirection.Input, entity.adres);
                        DBHelper.AddParameter(dbCommand, "@telefon", CsType.String, ParameterDirection.Input, entity.telefon);
                        DBHelper.AddParameter(dbCommand, "@ePosta", CsType.String, ParameterDirection.Input, entity.ePosta);
                        DBHelper.AddParameter(dbCommand, "@yildizSayisi", CsType.Int, ParameterDirection.Input, entity.yildizSayisi);
                        DBHelper.AddParameter(dbCommand, "@odaSayisi", CsType.Int, ParameterDirection.Input, entity.odaSayisi);
                        DBHelper.AddParameter(dbCommand, "@odaTipi", CsType.String, ParameterDirection.Input, entity.odaTipi);
                        DBHelper.AddParameter(dbCommand, "@otelPuani", CsType.Decimal, ParameterDirection.Input, entity.otelPuani);
                        DBHelper.AddParameter(dbCommand, "@oySayisi", CsType.Int, ParameterDirection.Input, entity.oySayisi);

                        //Output Params
                        DBHelper.AddParameter(dbCommand, "@intErrorCode", CsType.Int, ParameterDirection.Output, null);

                        //Open Connection
                        if (dbConnection.State != ConnectionState.Open)
                            dbConnection.Open();

                        //Execute query
                        _rowsAffected = dbCommand.ExecuteNonQuery();
                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());

                        if (_errorCode != 0)
                            throw new Exception("Inserting Error for entity [Otel] reported the Database ErrorCode: " + _errorCode);
                    }
                }
                //Return the results of query/ies
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("OtelRepository::Insert:Error occured.", ex);
            }
        }


        public List<Otel> OtelleriAl()
        {
            List<Otel> otelBilgileri = new List<Otel>();
            try
            {
                    foreach (var otel in SelectAll())
                    {
                        otelBilgileri.Add(otel);
                    }

                
            }
            catch (Exception ex)
            {
                throw new Exception("OtelRepository::Hata Oluştu.", ex);
            }

            return otelBilgileri;
        }

        public override List<Otel> SelectAll()
        {
            _errorCode = 0;
            _rowsAffected = 0;

            List<Otel> otelListesi = new List<Otel>();

            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append("[otelID], [adi], [il], [ilce], [adres], [telefon], [ePosta], [yildizSayisi], [odaSayisi], [odaTipi], [otelPuani], [oySayisi] ");
                query.Append("FROM [dbo].[tblOtel] ");
                query.Append("SELECT @intErrorCode=@@ERROR; ");

                var commandText = query.ToString();
                query.Clear();

                using (var dbConnection = _dbProviderFactory.CreateConnection())
                {
                    if (dbConnection == null)
                        throw new ArgumentNullException("dbConnection", "The db connection can't be null.");

                    dbConnection.ConnectionString = _connectionString;

                    using (var dbCommand = _dbProviderFactory.CreateCommand())
                    {
                        if (dbCommand == null)
                            throw new ArgumentNullException(
                                "dbCommand" + " The db SelectById command for entity [Otel] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        //Input Parameters - None

                        //Output Parameters
                        DBHelper.AddParameter(dbCommand, "@intErrorCode", CsType.Int,
                            ParameterDirection.Output, null);

                        //Open Connection
                        if (dbConnection.State != ConnectionState.Open)
                            dbConnection.Open();

                        //Execute query.
                        using (var reader = dbCommand.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    var entity = new Otel();
                                    entity.otelID = reader.GetInt32(0);
                                    entity.adi = reader.GetString(1);
                                    entity.il = reader.GetString(2);
                                    entity.ilce = reader.GetString(3);
                                    entity.adres = reader.GetString(4);
                                    entity.telefon = reader.GetString(5);
                                    entity.ePosta = reader.GetString(6);
                                    entity.yildizSayisi = reader.GetInt32(7);
                                    entity.odaSayisi = reader.GetInt32(8);
                                    entity.odaTipi = reader.GetString(9);
                                    entity.otelPuani = reader.GetDecimal(10);
                                    entity.oySayisi = reader.GetInt32(11);

                                    otelListesi.Add(entity);
                                }
                            }

                        }

                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());

                        if (_errorCode != 0)
                        {
                            // Throw error.
                            throw new Exception("Selecting All Error for entity [Otel] reported the Database ErrorCode: " + _errorCode);

                        }
                    }
                }
                // Return list
                return otelListesi;
            }
            catch (Exception ex)
            {
                throw new Exception("OtelRepository::SelectAll:Error occured.", ex);
            }
        }

        public override Otel SelectedById(object id)
        {
            _errorCode = 0;
            _rowsAffected = 0;

            Otel otel = null;

            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append("[otelID], [adi], [il], [ilce], [adres], [telefon], [ePosta], [yildizSayisi], [odaSayisi], [odaTipi], [otelPuani], [oySayisi] ");
                query.Append("FROM [dbo].[tblOtel] ");
                query.Append("WHERE ");
                query.Append("[otelID] = @id ");
                query.Append("SELECT @intErrorCode=@@ERROR; ");

                var commandText = query.ToString();
                query.Clear();

                using (var dbConnection = _dbProviderFactory.CreateConnection())
                {
                    if (dbConnection == null)
                        throw new ArgumentNullException("dbConnection", "The db connection can't be null.");

                    dbConnection.ConnectionString = _connectionString;

                    using (var dbCommand = _dbProviderFactory.CreateCommand())
                    {
                        if (dbCommand == null)
                            throw new ArgumentNullException(
                                "dbCommand" + " The db SelectById command for entity [Otel] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        //Input Parameters
                        DBHelper.AddParameter(dbCommand, "@id", CsType.Int, ParameterDirection.Input, id);

                        //Output Parameters
                        DBHelper.AddParameter(dbCommand, "@intErrorCode", CsType.Int, ParameterDirection.Output, null);

                        //Open Connection
                        if (dbConnection.State != ConnectionState.Open)
                            dbConnection.Open();

                        //Execute query.
                        using (var reader = dbCommand.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    var entity = new Otel();
                                    entity.otelID = reader.GetInt32(0);
                                    entity.adi = reader.GetString(1);
                                    entity.il = reader.GetString(2);
                                    entity.ilce = reader.GetString(3);
                                    entity.adres = reader.GetString(4);
                                    entity.telefon = reader.GetString(5);
                                    entity.ePosta = reader.GetString(6);
                                    entity.yildizSayisi = reader.GetInt32(7);
                                    entity.odaSayisi = reader.GetInt32(8);
                                    entity.odaTipi = reader.GetString(9);
                                    entity.otelPuani = reader.GetDecimal(10);
                                    entity.oySayisi = reader.GetInt32(11);

                                    otel = entity;
                                    break;
                                }
                            }
                        }

                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());

                        if (_errorCode != 0)
                        {
                            // Throw error.
                            throw new Exception("Selecting Error for entity [Otel] reported the Database ErrorCode: " + _errorCode);
                        }
                    }
                }

                return otel;
            }
            catch (Exception ex)
            {
                throw new Exception("OtelRepository::SelectById:Error occured.", ex);
            }
        }


        public void OtelGuncelle(Otel otel)
        {


            try
            {
                bool isSuccess;
                
                    isSuccess = Update(otel);

                if (isSuccess)
                    System.Windows.Forms.MessageBox.Show("Başarıyla Güncellendi");
                else
                    System.Windows.Forms.
                MessageBox.Show("Güncellerken Hata Oluştu");

            }
            catch (Exception ex)
            {
                throw new Exception("OtelRepository::Hata Oluştu.", ex);
            }



        }

        public override bool Update(Otel entity)
        {
            _rowsAffected = 0;
            _errorCode = 0;

            try
            {
                var query = new StringBuilder();
                query.Append(" UPDATE [dbo].[tblOtel] ");
                query.Append(" SET [adi] = @adi, [il] = @il, [ilce] =  @ilce, [adres] = @adres, [telefon] = @telefon, [ePosta] = @ePosta, [yildizSayisi] = @yildizSayisi, [odaSayisi] = @odaSayisi, [odaTipi] = @odaTipi, [otelPuani] = @otelPuani, [oySayisi] = @oySayisi ");
                query.Append(" WHERE ");
                query.Append(" [otelID] = @otelID ");
                query.Append(" SELECT @intErrorCode = @@ERROR; ");

                var commandText = query.ToString();
                query.Clear();

                using (var dbConnection = _dbProviderFactory.CreateConnection())
                {
                    if (dbConnection == null)
                        throw new ArgumentNullException("dbConnection", "The db connection can't be null.");

                    dbConnection.ConnectionString = _connectionString;

                    using (var dbCommand = _dbProviderFactory.CreateCommand())
                    {
                        if (dbCommand == null)
                            throw new ArgumentNullException("dbCommand" + " The db Insert command for entity [Otel] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        //Input Params
                        DBHelper.AddParameter(dbCommand, "@otelID", CsType.Int, ParameterDirection.Input, entity.otelID);
                        DBHelper.AddParameter(dbCommand, "@adi", CsType.String, ParameterDirection.Input, entity.adi);
                        DBHelper.AddParameter(dbCommand, "@il", CsType.String, ParameterDirection.Input, entity.il);
                        DBHelper.AddParameter(dbCommand, "@ilce", CsType.String, ParameterDirection.Input, entity.ilce);
                        DBHelper.AddParameter(dbCommand, "@adres", CsType.String, ParameterDirection.Input, entity.adres);
                        DBHelper.AddParameter(dbCommand, "@telefon", CsType.String, ParameterDirection.Input, entity.telefon);
                        DBHelper.AddParameter(dbCommand, "@ePosta", CsType.String, ParameterDirection.Input, entity.ePosta);
                        DBHelper.AddParameter(dbCommand, "@yildizSayisi", CsType.Int, ParameterDirection.Input, entity.yildizSayisi);
                        DBHelper.AddParameter(dbCommand, "@odaSayisi", CsType.Int, ParameterDirection.Input, entity.odaSayisi);
                        DBHelper.AddParameter(dbCommand, "@odaTipi", CsType.String, ParameterDirection.Input, entity.odaTipi);
                        DBHelper.AddParameter(dbCommand, "@otelPuani", CsType.Decimal, ParameterDirection.Input, entity.otelPuani);
                        DBHelper.AddParameter(dbCommand, "@oySayisi", CsType.Int, ParameterDirection.Input, entity.oySayisi);

                        //Output Params
                        DBHelper.AddParameter(dbCommand, "@intErrorCode", CsType.Int, ParameterDirection.Output, null);

                        //Open Connection
                        if (dbConnection.State != ConnectionState.Open)
                            dbConnection.Open();

                        //Execute query
                        _rowsAffected = dbCommand.ExecuteNonQuery();
                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());

                        if (_errorCode != 0)
                            throw new Exception("Updating Error for entity [Otel] reported the Database ErrorCode: " + _errorCode);
                    }
                }
                //Return the results of query/ies
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("OtelRepository::Update:Error occured.", ex);
            }
        }
    }
}
