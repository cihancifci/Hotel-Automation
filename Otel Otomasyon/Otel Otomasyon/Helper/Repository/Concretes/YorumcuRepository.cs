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
    public class YorumcuRepository : Repository<Yorumcu>, IDisposable
    {

        public YorumcuRepository()
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

        public override bool DeletedById(object tcKimlikNo)
        {
            _errorCode = 0;
            _rowsAffected = 0;

            try
            {
                var query = new StringBuilder();
                query.Append("DELETE ");
                query.Append("FROM [dbo].[tblYorumcu] ");
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
                                "dbCommand" + " The db SelectById command for entity [Yorumcu] can't be null. ");

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
                                "Deleting Error for entity [Yorumcu] reported the Database ErrorCode: " + _errorCode);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("YorumcuRepository::Insert:Error occured.", ex);
            }
        }

        public void YorumEkle(Yorumcu yorumcu)
        {
            try
            {
                bool isSuccess;

                    isSuccess = Insert(yorumcu);

                

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

        public override bool Insert(Yorumcu entity)
        {
            _rowsAffected = 0;
            _errorCode = 0;

            try
            {
                var query = new StringBuilder();
                query.Append("INSERT [dbo].[tblYorumcu] ");
                query.Append(" ( [tcKimlikNo], [tamAdi], [ePosta], [yorum], [konakladigiOtelID] ) ");
                query.Append("VALUES ");
                query.Append(
                    "( @tcKimlikNo, @tamAdi, @ePosta, @yorum, @konakladigiOtelID ) ");
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
                            throw new ArgumentNullException("dbCommand" + " The db Insert command for entity [Yorumcu] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        //Input Params
                        DBHelper.AddParameter(dbCommand, "@tcKimlikNo", CsType.String, ParameterDirection.Input, entity.tcKimlikNo);
                        DBHelper.AddParameter(dbCommand, "@tamAdi", CsType.String, ParameterDirection.Input, entity.tamAdi);
                        DBHelper.AddParameter(dbCommand, "@ePosta", CsType.String, ParameterDirection.Input, entity.ePosta);
                        DBHelper.AddParameter(dbCommand, "@yorum", CsType.String, ParameterDirection.Input, entity.yorum);
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
                            throw new Exception("Inserting Error for entity [Yorumcu] reported the Database ErrorCode: " + _errorCode);
                    }
                }
                //Return the results of query/ies
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("YorumcuRepository::Insert:Error occured.", ex);
            }
        }


        public void YorumculariAl(List<Otel> otelBilgileri)
        {

            try
            {

                    foreach (var yorumcu in SelectAll())
                    {
                        for (int i = 0; i < otelBilgileri.Count; i++)
                        {
                            if (yorumcu.konakladigiOtelID == otelBilgileri[i].otelID)
                            {
                                otelBilgileri[i].yorumcu.YorumEkle(yorumcu);

                            }
                        }

                    }
                
            }


            catch (Exception ex)
            {
                throw new Exception("OtelRepository::Hata Oluştu.", ex);
            }


        }

        public override List<Yorumcu> SelectAll()
        {
            _errorCode = 0;
            _rowsAffected = 0;

            List<Yorumcu> yorumcuListesi = new List<Yorumcu>();

            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append("[tcKimlikNo], [tamAdi], [ePosta], [yorum], [konakladigiOtelID] ");
                query.Append("FROM [dbo].[tblYorumcu] ");
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
                                "dbCommand" + " The db SelectById command for entity [Yorumcu] can't be null. ");

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
                                    var entity = new Yorumcu();
                                    entity.tcKimlikNo = reader.GetString(0);
                                    entity.tamAdi = reader.GetString(1);
                                    entity.ePosta = reader.GetString(2);
                                    entity.yorum = reader.GetString(3);
                                    entity.konakladigiOtelID = reader.GetInt32(4);

                                    yorumcuListesi.Add(entity);
                                }
                            }

                        }

                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());

                        if (_errorCode != 0)
                        {
                            // Throw error.
                            throw new Exception("Selecting All Error for entity [Yorumcu] reported the Database ErrorCode: " + _errorCode);

                        }
                    }
                }
                // Return list
                return yorumcuListesi;
            }
            catch (Exception ex)
            {
                throw new Exception("YorumcuRepository::SelectAll:Error occured.", ex);
            }
        }

        public override Yorumcu SelectedById(object tcKimlikNo)
        {
            _errorCode = 0;
            _rowsAffected = 0;

            Yorumcu yorumcu = null;

            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append("[tcKimlikNo], [tamAdi], [ePosta], [yorum], [konakladigiOtelID] ");
                query.Append("FROM [dbo].[tblYorumcu] ");
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
                                "dbCommand" + " The db SelectById command for entity [Yorumcu] can't be null. ");

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
                                    var entity = new Yorumcu();
                                    entity.tcKimlikNo = reader.GetString(0);
                                    entity.tamAdi = reader.GetString(1);
                                    entity.ePosta = reader.GetString(2);
                                    entity.yorum = reader.GetString(3);
                                    entity.konakladigiOtelID = reader.GetInt32(4);

                                    yorumcu = entity;
                                    break;
                                }
                            }
                        }

                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());

                        if (_errorCode != 0)
                        {
                            // Throw error.
                            throw new Exception("Selecting Error for entity [Yorumcu] reported the Database ErrorCode: " + _errorCode);
                        }
                    }
                }

                return yorumcu;
            }
            catch (Exception ex)
            {
                throw new Exception("YorumcuRepository::SelectById:Error occured.", ex);
            }
        }

        public override bool Update(Yorumcu entity)
        {
            _rowsAffected = 0;
            _errorCode = 0;

            try
            {
                var query = new StringBuilder();
                query.Append(" UPDATE [dbo].[tblYorumcu] ");
                query.Append(" SET [tcKimlikNo] = @tcKimlikNo, [tamAdi] = @tamAdi, [ePosta] =  @ePosta, [yorum] = @yorum, [konakladigiOtelID] = @konakladigiOtelID ");
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
                            throw new ArgumentNullException("dbCommand" + " The db Insert command for entity [Yorumcu] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        //Input Params
                        DBHelper.AddParameter(dbCommand, "@tcKimlikNo", CsType.String, ParameterDirection.Input, entity.tcKimlikNo);
                        DBHelper.AddParameter(dbCommand, "@tamAdi", CsType.String, ParameterDirection.Input, entity.tamAdi);
                        DBHelper.AddParameter(dbCommand, "@ePosta", CsType.String, ParameterDirection.Input, entity.ePosta);
                        DBHelper.AddParameter(dbCommand, "@yorum", CsType.String, ParameterDirection.Input, entity.yorum);
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
                            throw new Exception("Updating Error for entity [Yorumcu] reported the Database ErrorCode: " + _errorCode);
                    }
                }
                //Return the results of query/ies
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("YorumcuRepository::Update:Error occured.", ex);
            }
        }
    }
}
