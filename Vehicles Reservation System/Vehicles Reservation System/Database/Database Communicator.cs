using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Vehicles_Reservation_System.Logic;

namespace Vehicles_Reservation_System.Database
{
    class Database_Communicator
    {
        private string message;

        #region Authenticators
        public string adminAuthenticator(string uname, string pword)
        {
            try
            {
                using (var context = new Vehicle_Reervation_DatabaseEntities())
                {
                    Admin admin = context.Admins.Where(a => a.ADMIN_UNAME == uname && a.ADMIN_PWORD == pword).FirstOrDefault<Admin>();

                    if (admin != null)
                        return admin.ADMIN_UNAME;
                    else
                        return "Invalid Credentials";
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string managerAuthenticator(string uname, string pword)
        {
            try
            {
                using (var context = new Vehicle_Reervation_DatabaseEntities())
                {
                    Manager manager = context.Managers.Where(a => a.MANAGER_UNAME == uname && a.MANAGER_PWORD == pword).FirstOrDefault<Manager>();

                    if (manager != null)
                        return manager.MANAGER_UNAME;
                    else
                        return "Invalid Credentials";
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string entryOpAuthenticator(string uname, string pword)
        {
            try
            {
                using (var context = new Vehicle_Reervation_DatabaseEntities())
                {
                    var query = context.EntryOperators.Where(a => a.UNAME == uname && a.PWORD == pword).FirstOrDefault<EntryOperator>();

                    if (query != null)
                        return uname;
                    else
                        return "Invalid Credentials";
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion EndAuthenticators

        #region ID Incrementors
        public int customerIDIncrementer()
        {
            try
            {
                using (var context = new Vehicle_Reervation_DatabaseEntities())
                {
                    var customers = context.Customers.OrderByDescending(x => x.CUSTOMER_ID);

                    if (customers.Count() > 0)
                    {
                        var lastId = customers.FirstOrDefault<Customer>();

                        return ++lastId.CUSTOMER_ID;
                    }
                    else
                        return 0;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int carIDIncrementer()
        {
            try
            {
                using (var context = new Vehicle_Reervation_DatabaseEntities())
                {
                    var cars = context.Cars.OrderByDescending(x => x.CAR_ID);

                    if (cars.Count() > 0)
                    {
                        var lastId = cars.FirstOrDefault<Car>();

                        return ++lastId.CAR_ID;
                    }
                    else
                        return 0;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int bookingIDIncrementer()
        {
            try
            {
                using (var context = new Vehicle_Reervation_DatabaseEntities())
                {
                    var bookings = context.Bookings.OrderByDescending(x => x.BOOKING__ID);

                    if (bookings.Count() > 0)
                    {
                        var lastId = bookings.FirstOrDefault<Booking>();

                        return ++lastId.BOOKING__ID;
                    }
                    else
                        return 0;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion ID Incrementors

        #region ComboBox Populators
        public List<EntryOperator> entryOpComboBoxPopulator()
        {
            try
            {
                using (var context = new Vehicle_Reervation_DatabaseEntities())
                {
                    List<EntryOperator> entryOps = context.EntryOperators.ToList<EntryOperator>();

                    return entryOps;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Manager> managerComboBoxPopulator()
        {
            try
            {
                using (var context = new Vehicle_Reervation_DatabaseEntities())
                {
                    List<Manager> managers = context.Managers.ToList<Manager>();

                    //List<Boss> bosses = managers.Cast<Boss>().ToList();

                    return managers;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Customer> customerComboBoxPopulator()
        {
            try
            {
                using (var context = new Vehicle_Reervation_DatabaseEntities())
                {
                    List<Customer> customers = context.Customers.ToList<Customer>();
                    return customers;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Car> carComboBoxPopulator()
        {
            try
            {
                using (var context = new Vehicle_Reervation_DatabaseEntities())
                {
                    List<Car> availableCars = context.Cars.Where(x => x.STATUS == "Available").ToList<Car>();

                    return availableCars;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Car> vehicleManagementComboBoxPopulator()
        {
            try
            {
                using (var context = new Vehicle_Reervation_DatabaseEntities())
                {
                    List<Car> availableCars = context.Cars.ToList<Car>();

                    return availableCars;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Booking> ReservationComboBoxPopulator()
        {
            try
            {
                using (var context = new Vehicle_Reervation_DatabaseEntities())
                {
                    List<Booking> reservations = context.Bookings.ToList<Booking>();

                    return reservations;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion ComboBox Populator

        #region DataGrid Populators
        public List<Object> adminDataGridPopulator()
        {
            try
            {
                using (var context = new Vehicle_Reervation_DatabaseEntities())
                {
                    List<Object> admins = context.Admins.Select(x => new { ADMIN_UNAME = x.ADMIN_UNAME, ADMIN_NAME = x.ADMIN_NAME }).ToList<Object>();

                    //operators.AddRange(context.Managers.Select(x => new { x.MANAGER_NAME, x.MANAGER_UNAME }).ToList<Object>());
                    //adminList.Add(admins);

                    return admins;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Object> entryOpDataGridPopulator()
        {
            try
            {
                using (var context = new Vehicle_Reervation_DatabaseEntities())
                {
                    List<Object> entryOps = context.EntryOperators.Select(x => new { UNAME = x.UNAME, ENTRYOP_NAME = x.ENTRYOP_NAME }).ToList<Object>();

                    //operators.AddRange(context.Managers.Select(x => new { x.MANAGER_NAME, x.MANAGER_UNAME }).ToList<Object>());
                    //adminList.Add(admins);

                    return entryOps;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Object> bookingDataGridPopulator()
        {
            try
            {
                using (var context = new Vehicle_Reervation_DatabaseEntities())
                {
                    List<Object> bookings = context.Bookings.Select(x => new { BOOKING__ID = x.BOOKING__ID, 
                                                                               CUSTOMER_ID = x.CUSTOMER_ID, 
                                                                               CAR_ID = x.CAR_ID,
                                                                               AMOUNT_DUE = x.AMOUNT_DUE,
                                                                               BOOKING_DATE = x.BOOKING_DATE,
                                                                               RETURN_DATE = x.RETURN_DATE
                    }).ToList<Object>();

                    return bookings;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion DataGrid Populators

        #region Operations for Entry Operator
        public string addEntryOperator(EntryOp entryOp)
        {
            try
            {
                using (var context = new Vehicle_Reervation_DatabaseEntities())
                {
                    var entryOperator = new EntryOperator()
                    {
                        ENTRYOP_NAME = entryOp.getEntryOpName(),
                        UNAME = entryOp.getEntryOpUname(),
                        PWORD = entryOp.getEntryOpPword()
                    };

                    if (context.EntryOperators.Any(x => x.UNAME == entryOperator.UNAME))
                        return null;
                    else
                    {
                        context.EntryOperators.Add(entryOperator);
                        context.SaveChanges();

                        return entryOperator.ENTRYOP_NAME;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string updateEntryOperator(EntryOp entryOp, string uname)
        {
            try
            {
                using (var context = new Vehicle_Reervation_DatabaseEntities())
                {

                    EntryOperator entryOperator = context.EntryOperators.Where(x => x.UNAME == uname).FirstOrDefault<EntryOperator>();
                    //context.Entry(manager).CurrentValues.SetValues(boss);

                    //manager.MANAGER_UNAME = boss.getManagerUname();
                    entryOperator.ENTRYOP_NAME = entryOp.getEntryOpName();
                    entryOperator.PWORD = entryOp.getEntryOpPword();


                    //var manager = new Manager()
                    //{
                    //    MANAGER_NAME = boss.getManagerName(),
                    //    MANAGER_UNAME = boss.getManagerUname(),
                    //    MANAGER_PWORD = boss.getManagerPword()
                    //};

                    context.SaveChanges();

                    return entryOperator.ENTRYOP_NAME;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string deleteEntryOperator(string name)
        {
            try
            {
                using (var context = new Vehicle_Reervation_DatabaseEntities())
                {
                    var entryOp = context.EntryOperators.Where(x => x.ENTRYOP_NAME == name).SingleOrDefault<EntryOperator>();

                    context.EntryOperators.Remove(entryOp);
                    context.SaveChanges();

                    return entryOp.ENTRYOP_NAME;
                }
            }
            catch (Exception e)
            {
                return "User not Found";
                throw e;
            }
        }

        public EntryOp entryOperatorCredentials(string uname)
        {
            try
            {
                using (var context = new Vehicle_Reervation_DatabaseEntities())
                {
                    EntryOperator entryOperator = context.EntryOperators.Where(a => a.UNAME == uname).FirstOrDefault<EntryOperator>();

                    if (entryOperator == null)
                        return null;
                    else
                    {
                        EntryOp entryOp = new EntryOp(entryOperator.UNAME, entryOperator.ENTRYOP_NAME, entryOperator.PWORD);

                        return entryOp;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion Operations for Entry Operator

        #region Operations for Manager
        public string addManager(Boss boss)
        {
            try
            {
                using (var context = new Vehicle_Reervation_DatabaseEntities())
                {
                    var manager = new Manager()
                    {
                        MANAGER_NAME = boss.getManagerName(),
                        MANAGER_UNAME = boss.getManagerUname(),
                        MANAGER_PWORD = boss.getManagerPword()
                    };

                    if (context.Managers.Any(x => x.MANAGER_UNAME == manager.MANAGER_UNAME))
                        return null;
                    else
                    {
                        context.Managers.Add(manager);
                        context.SaveChanges();

                        return manager.MANAGER_NAME;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string updateManager(Boss boss, string uname)
        {
            try
            {
                using (var context = new Vehicle_Reervation_DatabaseEntities())
                {

                    Manager manager = context.Managers.Where(x => x.MANAGER_UNAME == uname).FirstOrDefault<Manager>();
                    //context.Entry(manager).CurrentValues.SetValues(boss);

                    //manager.MANAGER_UNAME = boss.getManagerUname();
                    manager.MANAGER_NAME = boss.getManagerName();
                    manager.MANAGER_PWORD = boss.getManagerPword();


                    //var manager = new Manager()
                    //{
                    //    MANAGER_NAME = boss.getManagerName(),
                    //    MANAGER_UNAME = boss.getManagerUname(),
                    //    MANAGER_PWORD = boss.getManagerPword()
                    //};

                    context.SaveChanges();

                    return manager.MANAGER_UNAME;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string deleteManager(string name)
        {
            try
            {
                using (var context = new Vehicle_Reervation_DatabaseEntities())
                {
                    var manager = context.Managers.Where(x => x.MANAGER_NAME == name).SingleOrDefault<Manager>();

                    context.Managers.Remove(manager);
                    context.SaveChanges();

                    return manager.MANAGER_NAME;
                }
            }
            catch (Exception e)
            {
                return "User not Found";
                throw e;
            }
        }

        public Boss managerCredentials(string uname)
        {
            try
            {
                using (var context = new Vehicle_Reervation_DatabaseEntities())
                {
                    Manager manager = context.Managers.Where(a => a.MANAGER_UNAME == uname).FirstOrDefault<Manager>();

                    if (manager == null)
                        return null;
                    else
                    {
                        Boss boss = new Boss(manager.MANAGER_UNAME, manager.MANAGER_NAME, manager.MANAGER_PWORD);

                        return boss;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion Operations for Manager

        #region Operations for Customer
        //public string deleteCustomer(string name)
        //{
        //    try
        //    {
        //        using (var context = new Vehicle_Reervation_DatabaseEntities())
        //        {
        //            var customer = context.Customers.Where(x => x.NAME == name).SingleOrDefault<Customer>();

        //            context.Customers.Remove(customer);
        //            context.SaveChanges();

        //            return customer.NAME;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        return "User not Found";
        //        throw e;
        //    }
        //}
        public bool deleteClient(string name)
        {
            try
            {
                using (var context = new Vehicle_Reervation_DatabaseEntities())
                {
                    Customer customer = context.Customers.Where(a => a.NAME == name).FirstOrDefault<Customer>();

                    if (customer != null)
                    {
                        context.Customers.Remove(customer);
                        context.SaveChanges();

                        return true;
                    }
                    else
                        return false;
                }
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }

            return false;
        }

        public string addCustomer(Client client)
        {
            try
            {
                using (var context = new Vehicle_Reervation_DatabaseEntities())
                {
                    var customer = new Customer()
                    {
                        CUSTOMER_ID = client.getCustomerId(),
                        NAME = client.getCustomerName(),
                        ADDRESS = client.getCustomerAddress(),
                        CNIC = client.getCustomerCnic(),
                        LICENSE_NO = client.getCustomerLicense(),
                        PHONE = client.getCustomerPhone(),
                        DOB = client.getCustomerDoB(),

                    };

                    if (context.Customers.Any(x => x.CNIC == customer.CNIC))
                        return null;
                    else
                    {
                        context.Customers.Add(customer);
                        context.SaveChanges();

                        int id = customer.CUSTOMER_ID;

                        return customer.NAME;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string updateCustomer(Client client, int id)
        {
            try
            {
                using (var context = new Vehicle_Reervation_DatabaseEntities())
                {

                    Customer customer = context.Customers.Where(x => x.CUSTOMER_ID == id).FirstOrDefault<Customer>();
                    //context.Entry(manager).CurrentValues.SetValues(boss);

                    //manager.MANAGER_UNAME = boss.getManagerUname();
                    customer.CUSTOMER_ID = client.getCustomerId();
                    customer.NAME = client.getCustomerName();
                    customer.PHONE = client.getCustomerPhone();
                    customer.LICENSE_NO = client.getCustomerLicense();
                    customer.CNIC = client.getCustomerCnic();
                    customer.ADDRESS = client.getCustomerAddress();
                    customer.DOB = client.getCustomerDoB();


                    //var manager = new Manager()
                    //{
                    //    MANAGER_NAME = boss.getManagerName(),
                    //    MANAGER_UNAME = boss.getManagerUname(),
                    //    MANAGER_PWORD = boss.getManagerPword()
                    //};

                    context.SaveChanges();

                    return customer.NAME;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Client customerUpdateCredentials(int id)
        {
            try
            {
                using (var context = new Vehicle_Reervation_DatabaseEntities())
                {
                    Customer customer = context.Customers.Where(a => a.CUSTOMER_ID == id).FirstOrDefault<Customer>();

                    if (customer == null)
                        return null;
                    else
                    {
                        Client client = new Client(customer.CUSTOMER_ID, customer.NAME, customer.ADDRESS, customer.CNIC, customer.LICENSE_NO, customer.PHONE, customer.DOB);

                        return client;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Client customerRemovalCredentials(string name)
        {
            try
            {
                using (var context = new Vehicle_Reervation_DatabaseEntities())
                {
                    Customer customer = context.Customers.Where(a => a.NAME == name).FirstOrDefault<Customer>();

                    if (customer == null)
                        return null;
                    else
                    {
                        Client client = new Client(customer.CUSTOMER_ID, customer.NAME, customer.ADDRESS, customer.CNIC, customer.LICENSE_NO, customer.PHONE, customer.DOB);

                        return client;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion Operations for Customer

        #region Operations for Vehicle
        public string addVehicle(Vehicle tempVehicle)
        {
            try
            {
                using (var context = new Vehicle_Reervation_DatabaseEntities())
                {
                    var car = new Car()
                    {
                        CAR_ID = tempVehicle.getCarId(),
                        CAR_NAME = tempVehicle.getCarName(),
                        CATEGORY = tempVehicle.getCarCategory(),
                        COLOR = tempVehicle.getCarColor(),
                        MFG_DATE = tempVehicle.getCarMfgDate(),
                        INSURANCE_NO = tempVehicle.getCarInsurance(),
                        REG_NO = tempVehicle.getCarRegNo(),
                        RATE_PER_DAY = tempVehicle.getCarRatePerDay(),
                        STATUS = "Available",
                        DATE_OF_INCLUSION = DateTime.Today
                    };

                    context.Cars.Add(car);
                    context.SaveChanges();

                    return car.CAR_NAME;
                    //MessageBox.Show(car.CAR_NAME + " has been Added Successfully");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string updateStatus(string regNo, string status)
        {
            try
            {
                using (var context = new Vehicle_Reervation_DatabaseEntities())
                {

                    Car car = context.Cars.Where(x => x.REG_NO == regNo).FirstOrDefault<Car>();
                    //context.Entry(manager).CurrentValues.SetValues(boss);

                    //manager.MANAGER_UNAME = boss.getManagerUname();
                    car.STATUS = status;
                    //var manager = new Manager()
                    //{
                    //    MANAGER_NAME = boss.getManagerName(),
                    //    MANAGER_UNAME = boss.getManagerUname(),
                    //    MANAGER_PWORD = boss.getManagerPword()
                    //};

                    context.SaveChanges();

                    return "Status changed Successfully";
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string deleteVehicle(int id)
        {
            try
            {
                using (var context = new Vehicle_Reervation_DatabaseEntities())
                {
                    var car = context.Cars.Where(a => a.CAR_ID == id).FirstOrDefault<Car>();

                    context.Cars.Remove(car);
                    context.SaveChanges();

                    return car.REG_NO;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void changeCarStatus(int id)
        {
            try
            {
                using (var context = new Vehicle_Reervation_DatabaseEntities())
                {

                    Car car = context.Cars.Where(x => x.CAR_ID == id).FirstOrDefault<Car>();
                    //context.Entry(manager).CurrentValues.SetValues(boss);

                    //manager.MANAGER_UNAME = boss.getManagerUname();
                    car.STATUS = "Reserved";
                    //var manager = new Manager()
                    //{
                    //    MANAGER_NAME = boss.getManagerName(),
                    //    MANAGER_UNAME = boss.getManagerUname(),
                    //    MANAGER_PWORD = boss.getManagerPword()
                    //};

                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public float giveRatePerDay(int carId)
        {
            try
            {
                using (var context = new Vehicle_Reervation_DatabaseEntities())
                {
                    var query = context.Cars.Where(a => a.CAR_ID == carId).FirstOrDefault<Car>();

                    if (query == null)
                        return 0;
                    else
                        return (float)query.RATE_PER_DAY;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string returnStatus(string regNo)
        {
            try
            {
                using (var context = new Vehicle_Reervation_DatabaseEntities())
                {
                    Car car = context.Cars.Where(a => a.REG_NO == regNo).FirstOrDefault<Car>();

                    if (car != null)
                        return car.STATUS;
                    else
                        return null;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion Operations for Vehicle

        #region Operations for Reservation
        public Reservation reservationDetails(int id)
        {
            try
            {
                using (var context = new Vehicle_Reervation_DatabaseEntities())
                {
                    Booking booking = context.Bookings.Where(a => a.BOOKING__ID == id).FirstOrDefault<Booking>();

                    if (booking == null)
                        return null;
                    else
                    {
                        Reservation reservation = new Reservation(booking.BOOKING__ID, booking.CUSTOMER_ID, booking.CAR_ID, (float)booking.AMOUNT_DUE, booking.BOOKING_DATE, booking.RETURN_DATE);

                        return reservation;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string addBooking(List<Reservation> listOfReservations)
        {
            try
            {
                using (var context = new Vehicle_Reervation_DatabaseEntities())
                {
                    foreach (Reservation r in listOfReservations)
                    {
                        var booking = new Booking()
                        {
                            BOOKING__ID = r.getBookingId(),
                            CUSTOMER_ID = r.getCustomerId(),
                            CAR_ID = r.getCarId(),
                            BOOKING_DATE = r.getBookingDate(),
                            AMOUNT_DUE = r.getBookingAmountDue(),
                            RETURN_DATE = r.getReturnDate(),
                        };
                        context.Bookings.Add(booking);
                    }
                    context.SaveChanges();

                    return "Reservation has been made";
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion Operations for Reservation

        #region Operation for Admin
        public string addAdmin(Administrator tempAdmin)
        {
            try
            {
                using (var context = new Vehicle_Reervation_DatabaseEntities())
                {
                    Admin admin = new Admin
                    {
                        ADMIN_NAME = tempAdmin.getAdminName(),
                        ADMIN_UNAME = tempAdmin.getAdminUname(),
                        ADMIN_PWORD = tempAdmin.getAdminPword()
                    };

                    if (context.Admins.Any(x => x.ADMIN_UNAME == admin.ADMIN_UNAME))
                        return null;
                    else
                    {
                        context.Admins.Add(admin);
                        context.SaveChanges();

                        return admin.ADMIN_UNAME;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion Operation for Admin

        //public string deleteCustomer(string name)
        //{
        //    try
        //    {
        //        using (var context = new Vehicle_Reervation_DatabaseEntities())
        //        {
        //            var customer = context.Customers.Where(x => x.NAME == name).SingleOrDefault<Customer>();

        //            context.Customers.Remove(customer);
        //            context.SaveChanges();

        //            return customer.NAME;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        return "User not Found";
        //        throw e;
        //    }
        //}

        //public string addCustomer(Client client)
        //{
        //    try
        //    {
        //        using (var context = new Vehicle_Reervation_DatabaseEntities())
        //        {
        //            var customer = new Customer()
        //            {
        //                CUSTOMER_ID = client.getCustomerId(),
        //                NAME = client.getCustomerName(),
        //                ADDRESS = client.getCustomerAddress(),
        //                CNIC = client.getCustomerCnic(),
        //                LICENSE_NO = client.getCustomerLicense(),
        //                PHONE = client.getCustomerPhone(),
        //                DOB =  client.getCustomerDoB(),
 
        //            };

        //            context.Customers.Add(customer);
        //            context.SaveChanges();

        //            int id = customer.CUSTOMER_ID;

        //            return customer.NAME;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}

        //public string updateCustomer(Client client, int id)
        //{
        //    try
        //    {
        //        using (var context = new Vehicle_Reervation_DatabaseEntities())
        //        {

        //            Customer customer = context.Customers.Where(x => x.CUSTOMER_ID == id).FirstOrDefault<Customer>();
        //            //context.Entry(manager).CurrentValues.SetValues(boss);

        //            //manager.MANAGER_UNAME = boss.getManagerUname();
        //            customer.CUSTOMER_ID = client.getCustomerId();
        //            customer.NAME = client.getCustomerName();
        //            customer.PHONE = client.getCustomerPhone();
        //            customer.LICENSE_NO = client.getCustomerLicense();
        //            customer.CNIC = client.getCustomerCnic();
        //            customer.ADDRESS = client.getCustomerAddress();
        //            customer.DOB = client.getCustomerDoB();


        //            //var manager = new Manager()
        //            //{
        //            //    MANAGER_NAME = boss.getManagerName(),
        //            //    MANAGER_UNAME = boss.getManagerUname(),
        //            //    MANAGER_PWORD = boss.getManagerPword()
        //            //};

        //            context.SaveChanges();

        //            return customer.NAME;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}

        //public bool deleteClient(string name)
        //{
        //    try
        //    {
        //        using (var context = new Vehicle_Reervation_DatabaseEntities())
        //        {
        //            Customer customer = context.Customers.Where(a => a.NAME == name).FirstOrDefault<Customer>();

        //            if (customer != null)
        //            {
        //                context.Customers.Remove(customer);
        //                context.SaveChanges();

        //                return true;
        //            }
        //            else
        //                return false;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.Write(e.StackTrace);
        //    }

        //    return false;
        //}

        #region Operations for PDF Report
        public int totalBookingsToDate()
        {
            using(Vehicle_Reervation_DatabaseEntities context = new Vehicle_Reervation_DatabaseEntities())
            {
                int totalBookings = context.Bookings.Count();

                return totalBookings;
            }
        }

        public int thisMonthBookings()
        {
            using(Vehicle_Reervation_DatabaseEntities context = new Vehicle_Reervation_DatabaseEntities())
            {
                int bookingsThisMonth = context.Bookings.Where(x => x.BOOKING_DATE.Month == DateTime.Today.Month).Count();

                return bookingsThisMonth;
            }
        }

        public double totalIncomeGenerated()
        {
            using (Vehicle_Reervation_DatabaseEntities context = new Vehicle_Reervation_DatabaseEntities())
            {
                double income = context.Bookings.Sum(x => x.AMOUNT_DUE);

                return income;
            }
        }

        public double thisMonthIncomeGenerated()
        {
            using (Vehicle_Reervation_DatabaseEntities context = new Vehicle_Reervation_DatabaseEntities())
            {
                double income = context.Bookings.Where(x => x.BOOKING_DATE.Month == DateTime.Today.Month).Sum(x => x.AMOUNT_DUE);

                return income;
            }
        }

        public int totalCustomers()
        {
            using (Vehicle_Reervation_DatabaseEntities context = new Vehicle_Reervation_DatabaseEntities())
            {
                int totalCustomers = context.Customers.Count();

                return totalCustomers;
            }
        }

        public int thisMonthCustomers()
        {
            using (Vehicle_Reervation_DatabaseEntities context = new Vehicle_Reervation_DatabaseEntities())
            {
                int thisMonthCustomers = context.Customers.Where(x => x.DATE_OF_REG.Month == DateTime.Today.Month).Count();

                return thisMonthCustomers;
            }
        }

        public int totalVehicles()
        {
            using (Vehicle_Reervation_DatabaseEntities context = new Vehicle_Reervation_DatabaseEntities())
            {
                int totalVehicles = context.Cars.Count();

                return totalVehicles;
            }
        }

        public int thisMonthVehicles()
        {
            using (Vehicle_Reervation_DatabaseEntities context = new Vehicle_Reervation_DatabaseEntities())
            {
                int thisMonthVehicles = context.Cars.Where(x => x.DATE_OF_INCLUSION.Month == DateTime.Today.Month).Count();

                return thisMonthVehicles;
            }
        }

        public int totalSedans()
        {
            using (Vehicle_Reervation_DatabaseEntities context = new Vehicle_Reervation_DatabaseEntities())
            {
                int totalVehicles = context.Cars.Where(x => x.CATEGORY == "Sedan").Count();

                return totalVehicles;
            }
        }

        public int totalHybrids()
        {
            using (Vehicle_Reervation_DatabaseEntities context = new Vehicle_Reervation_DatabaseEntities())
            {
                int totalVehicles = context.Cars.Where(x => x.CATEGORY == "Hybrid").Count();

                return totalVehicles;
            }
        }

        public int totalJeeps()
        {
            using (Vehicle_Reervation_DatabaseEntities context = new Vehicle_Reervation_DatabaseEntities())
            {
                int totalVehicles = context.Cars.Where(x => x.CATEGORY == "Jeep").Count();

                return totalVehicles;
            }
        }
        #endregion Operations for PDF Report

        //public List<Object> customerDetailForInvoice(int id)
        //{
        //    using (Vehicle_Reervation_DatabaseEntities context = new Vehicle_Reervation_DatabaseEntities())
        //    {
        //        Customer customer = context.Customers.Where(x => x.CUSTOMER_ID == id)
        //                                                .Select(x => new Customer
        //                                                {
        //                                                    CUSTOMER_ID = x.CUSTOMER_ID,
        //                                                    NAME = x.NAME,
        //                                                    ADDRESS = x.ADDRESS,
        //                                                    CNIC = x.CNIC,
        //                                                    LICENSE_NO = x.LICENSE_NO,
        //                                                    PHONE = x.PHONE,
        //                                                    DOB = x.DOB
        //                                                });
        //        return customer;
        //    }
        //}
    }
}