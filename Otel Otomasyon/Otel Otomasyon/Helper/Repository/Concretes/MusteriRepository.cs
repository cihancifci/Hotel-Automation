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
    public class MusteriRepository : Repository<Musteri>, IDisposable
    {

        public MusteriRepository()
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

        public void MusteriSil(Musteri musteri)
        {
            try
            {
                bool isSuccess;

                isSuccess = DeletedById(musteri.tcKimlikNo);

                if (isSuccess)
                    System.Windows.Forms.MessageBox.Show("Başarıyla Yapıldı!");
                else
                    System.Windows.Forms.MessageBox.Show("Yapılırken Hata Oluştu");
            }
            catch (Exception ex)
            {
                throw new Exception("MusteriRepository::Hata Oluştu.", ex);
            }
        }

        public override bool DeletedById(object tcKimlikNo)
        {
            _errorCode = 0;
            _rowsAffected = 0;

            try
            {
                var query = new StringBuilder();
                query.Append("DELETE ");
                query.Append("FROM [dbo].[tblMusteri] ");
                query.Append("WHERE ");
                query.Append("[tcKimlikNo] = @tcKimlikNo ");
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
                                "dbCommand" + " The db SelectById command for entity [Musteri] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        //Input Parameters
                        DBHelper.AddParameter(dbCommand, "@tcKimlikNo", CsType.String, ParameterDirection.Input, tcKimlikNo);

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
                                "Deleting Error for entity [Musteri] reported the Database ErrorCode: " + _errorCode);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("MusteriRepository::Insert:Error occured.", ex);
            }
        }

        public override bool Insert(Musteri entity)
        {
            _rowsAffected = 0;
            _errorCode = 0;

            try
            {
                var query = new StringBuilder();
                query.Append("INSERT [dbo].[tblMusteri] ");
                query.Append(" ( [tcKimlikNo], [tamAdi], [ePosta], [konakladigiOtelID] ) ");
                query.Append("VALUES ");
                query.Append(
                    "( @tcKimlikNo, @tamAdi, @ePosta, @konakladigiOtelID ) ");
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
                            throw new ArgumentNullException("dbCommand" + " The db Insert command for entity [Musteri] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        //Input Params
                        DBHelper.AddParameter(dbCommand, "@tcKimlikNo", CsType.String, ParameterDirection.Input, entity.tcKimlikNo);
                        DBHelper.AddParameter(dbCommand, "@tamAdi", CsType.String, ParameterDirection.Input, entity.tamAdi);
                        DBHelper.AddParameter(dbCommand, "@ePosta", CsType.String, ParameterDirection.Input, entity.ePosta);
                        DBHelper.AddParameter(dbCommand, "@konakladigiOtelID", CsType.Int, ParameterDirection.Input, entity.konakladigiOtelID);

                        //Output Params
                        DBHelper.AddParameter(dbCommand, "@intErrorCode", CsType.Int, ParameterDirection.Output, null);

                        //Open Connection
                        if (dbConnection.State != ConnectionState.Open)
                            dbConnection.Open();

                        //Execute query
                        _rowsAffected = dbCommand.ExecuteNonQuery();
                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());

                        if (_errorCode != 0)
                            throw new Exception("Inserting Error for entity [Musteri] reported the Database ErrorCode: " + _errorCode);
                    }
                }
                //Return the results of query/ies
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("MusteriRepository::Insert:Error occured.", ex);
            }
        }

        public override List<Musteri> SelectAll()
        {
            _errorCode = 0;
            _rowsAffected = 0;

            List<Musteri> musteriListesi = new List<Musteri>();

            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append("[tcKimlikNo], [tamAdi], [ePosta], [konakladigiOtelID] ");
                query.Append("FROM [dbo].[tblMusteri] ");
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
                                "dbCommand" + " The db SelectById command for entity [Musteri] can't be null. ");

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
                                    var entity = new Musteri();
                                    entity.tcKimlikNo = reader.GetString(0);
                                    entity.tamAdi = reader.GetString(1);
                                    entity.ePosta = reader.GetString(2);
                                    entity.konakladigiOtelID = reader.GetInt32(3);

                                    musteriListesi.Add(entity);
                                }
                            }

                        }

                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());

                        if (_errorCode != 0)
                        {
                            // Throw error.
                            throw new Exception("Selecting All Error for entity [Musteri] reported the Database ErrorCode: " + _errorCode);

                        }
                    }
                }
                // Return list
                return musteriListesi;
            }
            catch (Exception ex)
            {
                throw new Exception("MusteriRepository::SelectAll:Error occured.", ex);
            }
        }

        public Musteri MusteriBul(string id)
        {
            Musteri musteri;
            try
            {
                bool isSuccess = false;

                musteri = SelectedById(id);

                if (musteri != null)
                    isSuccess = true;

                if (isSuccess)
                    System.Windows.Forms.MessageBox.Show("Bulundu!");
                else
                    System.Windows.Forms.MessageBox.Show("Bulunamadı!");
            }
            catch (Exception ex)
            {
                throw new Exception("MusteriRepository::Hata Oluştu.", ex);
            }

            return musteri;
        }

        public override Musteri SelectedById(object tcKimlikNo)
        {
            _errorCode = 0;
            _rowsAffected = 0;

            Musteri musteri = null;

            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append("[tcKimlikNo], [tamAdi], [ePosta], [konakladigiOtelID] ");
                query.Append("FROM [dbo].[tblMusteri] ");
                query.Append("WHERE ");
                query.Append("[tcKimlikNo] = @tcKimlikNo ");
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
                                "dbCommand" + " The db SelectById command for entity [Musteri] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        //Input Parameters
                        DBHelper.AddParameter(dbCommand, "@tcKimlikNo", CsType.String, ParameterDirection.Input, tcKimlikNo);

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
                                    var entity = new Musteri();
                                    entity.tcKimlikNo = reader.GetString(0);
                                    entity.tamAdi = reader.GetString(1);
                                    entity.ePosta = reader.GetString(2);
                                    entity.konakladigiOtelID = reader.GetInt32(3);

                                    musteri = entity;
                                    break;
                                }
                            }
                        }

                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());

                        if (_errorCode != 0)
                        {
                            // Throw error.
                            throw new Exception("Selecting Error for entity [Musteri] reported the Database ErrorCode: " + _errorCode);
                        }
                    }
                }

                return musteri;
            }
            catch (Exception ex)
            {
                throw new Exception("MusteriRepository::SelectById:Error occured.", ex);
            }
        }

        public override bool Update(Musteri entity)
        {
            _rowsAffected = 0;
            _errorCode = 0;

            try
            {
                var query = new StringBuilder();
                query.Append(" UPDATE [dbo].[tblMusteri] ");
                query.Append(" SET [tcKimlikNo] = @tcKimlikNo, [tamAdi] = @tamAdi, [ePosta] =  @ePosta, [konakladigiOtelID] = @konakladigiOtelID ");
                query.Append(" WHERE ");
                query.Append(" [tcKimlikNo] = @tcKimlikNo ");
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
                            throw new ArgumentNullException("dbCommand" + " The db Insert command for entity [Musteri] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        //Input Params
                        DBHelper.AddParameter(dbCommand, "@tcKimlikNo", CsType.String, ParameterDirection.Input, entity.tcKimlikNo);
                        DBHelper.AddParameter(dbCommand, "@tamAdi", CsType.String, ParameterDirection.Input, entity.tamAdi);
                        DBHelper.AddParameter(dbCommand, "@ePosta", CsType.String, ParameterDirection.Input, entity.ePosta);
                        DBHelper.AddParameter(dbCommand, "@konakladigiOtelID", CsType.Int, ParameterDirection.Input, entity.konakladigiOtelID);

                        //Output Params
                        DBHelper.AddParameter(dbCommand, "@intErrorCode", CsType.Int, ParameterDirection.Output, null);

                        //Open Connection
                        if (dbConnection.State != ConnectionState.Open)
                            dbConnection.Open();

                        //Execute query
                        _rowsAffected = dbCommand.ExecuteNonQuery();
                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());

                        if (_errorCode != 0)
                            throw new Exception("Updating Error for entity [Musteri] reported the Database ErrorCode: " + _errorCode);
                    }
                }
                //Return the results of query/ies
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("MusteriRepository::Update:Error occured.", ex);
            }
        }
    }
}
