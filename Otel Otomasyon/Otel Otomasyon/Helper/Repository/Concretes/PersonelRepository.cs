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
    public class PersonelRepository : Repository<Personel>, IDisposable
    {

        public PersonelRepository()
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



        public void PersonelSil(Personel personel)
        {
            try
            {
                bool isSuccess;
                
                    isSuccess = DeletedById(personel.tcKimlikNo);
                

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

        public override bool DeletedById(object tcKimlikNo)
        {
            _errorCode = 0;
            _rowsAffected = 0;

            try
            {
                var query = new StringBuilder();
                query.Append("DELETE ");
                query.Append("FROM [dbo].[tblPersonel] ");
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
                                "dbCommand" + " The db SelectById command for entity [Personel] can't be null. ");

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
                                "Deleting Error for entity [Personel] reported the Database ErrorCode: " + _errorCode);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("PersonelRepository::Insert:Error occured.", ex);
            }
        }



        public void PersonelEkle(Personel personel)
        {
            try
            {
                bool isSuccess;

                    isSuccess = Insert(personel);
                    

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

        public override bool Insert(Personel entity)
        {
            _rowsAffected = 0;
            _errorCode = 0;

            try
            {
                var query = new StringBuilder();
                query.Append("INSERT [dbo].[tblPersonel] ");
                query.Append(" ( [tcKimlikNo], [telefon], [adres], [departman], [pozisyon], [personelPuani], [tamAdi], [ePosta], [calistigiOtelID] ) ");
                query.Append("VALUES ");
                query.Append(
                    "( @tcKimlikNo,@telefon, @adres, @departman, @pozisyon, @personelPuani, @tamAdi, @ePosta, @calistigiOtelID ) ");
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
                            throw new ArgumentNullException("dbCommand" + " The db Insert command for entity [Personel] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        //Input Params
                        DBHelper.AddParameter(dbCommand, "@tcKimlikNo", CsType.String, ParameterDirection.Input, entity.tcKimlikNo);
                        DBHelper.AddParameter(dbCommand, "@telefon", CsType.String, ParameterDirection.Input, entity.telefon);
                        DBHelper.AddParameter(dbCommand, "@adres", CsType.String, ParameterDirection.Input, entity.adres);
                        DBHelper.AddParameter(dbCommand, "@departman", CsType.String, ParameterDirection.Input, entity.departman);
                        DBHelper.AddParameter(dbCommand, "@pozisyon", CsType.String, ParameterDirection.Input, entity.pozisyon);
                        DBHelper.AddParameter(dbCommand, "@personelPuani", CsType.Decimal, ParameterDirection.Input, entity.personelPuani);
                        DBHelper.AddParameter(dbCommand, "@tamAdi", CsType.String, ParameterDirection.Input, entity.tamAdi);
                        DBHelper.AddParameter(dbCommand, "@ePosta", CsType.String, ParameterDirection.Input, entity.ePosta);
                        DBHelper.AddParameter(dbCommand, "@calistigiOtelID", CsType.Int, ParameterDirection.Input, entity.calistigiOtelID);

                        //Output Params
                        DBHelper.AddParameter(dbCommand, "@intErrorCode", CsType.Int, ParameterDirection.Output, null);

                        //Open Connection
                        if (dbConnection.State != ConnectionState.Open)
                            dbConnection.Open();

                        //Execute query
                        _rowsAffected = dbCommand.ExecuteNonQuery();
                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());

                        if (_errorCode != 0)
                            throw new Exception("Inserting Error for entity [Personel] reported the Database ErrorCode: " + _errorCode);
                    }
                }
                //Return the results of query/ies
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("PersonelRepository::Insert:Error occured.", ex);
            }
        }


        public List<Personel> TumPersonelleriAl()
        {

            return SelectAll();

        }


        public override List<Personel> SelectAll()
        {
            _errorCode = 0;
            _rowsAffected = 0;

            List<Personel> personelListesi = new List<Personel>();

            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append("[tcKimlikNo], [telefon], [adres], [departman], [pozisyon], [personelPuani], [tamAdi], [ePosta], [calistigiOtelID] ");
                query.Append("FROM [dbo].[tblPersonel] ");
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
                                "dbCommand" + " The db SelectById command for entity [Personel] can't be null. ");

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

                                    var entity = new Personel();
                                    entity.tcKimlikNo = reader.GetString(0);
                                    entity.telefon = reader.GetString(1);
                                    entity.adres = reader.GetString(2);
                                    entity.departman = reader.GetString(3);
                                    entity.pozisyon = reader.GetString(4);
                                    entity.personelPuani = reader.GetDecimal(5);
                                    entity.tamAdi = reader.GetString(6);
                                    entity.ePosta = reader.GetString(7);
                                    entity.calistigiOtelID = reader.GetInt32(8);


                                    personelListesi.Add(entity);
                                }
                            }

                        }

                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());

                        if (_errorCode != 0)
                        {
                            // Throw error.
                            throw new Exception("Selecting All Error for entity [Personel] reported the Database ErrorCode: " + _errorCode);

                        }
                    }
                }
                // Return list
                return personelListesi;
            }
            catch (Exception ex)
            {
                throw new Exception("PersonelRepository::SelectAll:Error occured.", ex);
            }
        }

        public override Personel SelectedById(object tcKimlikNo)
        {
            _errorCode = 0;
            _rowsAffected = 0;

            Personel personel = null;

            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append("[tcKimlikNo], [telefon], [adres], [departman], [pozisyon], [personelPuani], [tamAdi], [ePosta], [calistigiOtelID] ");
                query.Append("FROM [dbo].[tblPersonel] ");
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
                                "dbCommand" + " The db SelectById command for entity [Personel] can't be null. ");

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
                                    var entity = new Personel();
                                    entity.tcKimlikNo = reader.GetString(0);
                                    entity.telefon = reader.GetString(1);
                                    entity.adres = reader.GetString(2);
                                    entity.departman = reader.GetString(3);
                                    entity.pozisyon = reader.GetString(3);
                                    entity.personelPuani = reader.GetDecimal(3);
                                    entity.tamAdi = reader.GetString(3);
                                    entity.ePosta = reader.GetString(3);
                                    entity.calistigiOtelID = reader.GetInt32(3);

                                    personel = entity;
                                    break;
                                }
                            }
                        }

                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());

                        if (_errorCode != 0)
                        {
                            // Throw error.
                            throw new Exception("Selecting Error for entity [Personel] reported the Database ErrorCode: " + _errorCode);
                        }
                    }
                }

                return personel;
            }
            catch (Exception ex)
            {
                throw new Exception("PersonelRepository::SelectById:Error occured.", ex);
            }
        }


        public void PersonelGuncelle(Personel personel)
        {
            
            try
            {
                bool isSuccess;

                    isSuccess = Update(personel);
                

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


        public override bool Update(Personel entity)
        {
            _rowsAffected = 0;
            _errorCode = 0;

            try
            {
                var query = new StringBuilder();
                query.Append(" UPDATE [dbo].[tblPersonel] ");
                query.Append(" SET [tcKimlikNo] = @tcKimlikNo, [telefon] = @telefon, [adres] =  @adres, [departman] = @departman, [pozisyon] = @pozisyon, [personelPuani] = @personelPuani, [tamAdi] = @tamAdi, [ePosta] = @ePosta, [calistigiOtelID] = @calistigiOtelID ");
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
                            throw new ArgumentNullException("dbCommand" + " The db Insert command for entity [Personel] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        //Input Params
                        DBHelper.AddParameter(dbCommand, "@tcKimlikNo", CsType.String, ParameterDirection.Input, entity.tcKimlikNo);
                        DBHelper.AddParameter(dbCommand, "@telefon", CsType.String, ParameterDirection.Input, entity.telefon);
                        DBHelper.AddParameter(dbCommand, "@adres", CsType.String, ParameterDirection.Input, entity.adres);
                        DBHelper.AddParameter(dbCommand, "@departman", CsType.String, ParameterDirection.Input, entity.departman);
                        DBHelper.AddParameter(dbCommand, "@pozisyon", CsType.String, ParameterDirection.Input, entity.pozisyon);
                        DBHelper.AddParameter(dbCommand, "@personelPuani", CsType.Decimal, ParameterDirection.Input, entity.personelPuani);
                        DBHelper.AddParameter(dbCommand, "@tamAdi", CsType.String, ParameterDirection.Input, entity.tamAdi);
                        DBHelper.AddParameter(dbCommand, "@ePosta", CsType.String, ParameterDirection.Input, entity.ePosta);
                        DBHelper.AddParameter(dbCommand, "@calistigiOtelID", CsType.Int, ParameterDirection.Input, entity.calistigiOtelID);

                        //Output Params
                        DBHelper.AddParameter(dbCommand, "@intErrorCode", CsType.Int, ParameterDirection.Output, null);

                        //Open Connection
                        if (dbConnection.State != ConnectionState.Open)
                            dbConnection.Open();

                        //Execute query
                        _rowsAffected = dbCommand.ExecuteNonQuery();
                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());

                        if (_errorCode != 0)
                            throw new Exception("Updating Error for entity [Personel] reported the Database ErrorCode: " + _errorCode);
                    }
                }
                //Return the results of query/ies
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("PersonelRepository::Update:Error occured.", ex);
            }
        }
    }
}
