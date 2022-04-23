using System;
using StadiumTaskEntity.Entities;

namespace StadiumTaskEntity
{
    class Program
    {
        static void Main(string[] args)
        {
            bool check = true;
            string chooseStr;
            int choose;
            string stadiumName;
            string username;
            string email;
            string hourPriceStr;
            int hourlyPrice;
            string capacityStr;
            byte capacity;
            string selectedIdStr;
            int selectedId;
            string startStr;
            DateTime start;
            string endStr;
            DateTime end;

            do
            {
                StadiumData stadiumData = new StadiumData();
                UserData userData = new UserData();
                ReservationData reservationData = new ReservationData();

                Console.WriteLine("-------------------Menu-----------------");
                Console.WriteLine("1. Stadion elave et");
                Console.WriteLine("2. Stadionlari goster");
                Console.WriteLine("3. Verilmis id-li stadionu goster");
                Console.WriteLine("4. Verilmis id-li stadionu sil");
                Console.WriteLine("5. Istifadeci elave et");
                Console.WriteLine("6. Istifadecileri goster");
                Console.WriteLine("7. Reservasiya elave et");
                Console.WriteLine("8. Verilmis id-li rezervasiyalari goster");
                Console.WriteLine("9. Rezervasiyalari goster");
                Console.WriteLine("0. Proqramdan cix");
                Console.WriteLine("----------------------------------------");

                bool chooseBool = false;
                do
                {
                    Console.WriteLine("Etmek istediyiniz emeliyyati secin:");
                    chooseStr = Console.ReadLine();
                    chooseBool = int.TryParse(chooseStr, out choose);
                } while (chooseBool == false);

                switch (choose)
                {
                    case 1:

                        do
                        {
                            Console.WriteLine("Stadion adini daxil edin:");
                            stadiumName = Console.ReadLine();
                        } while (stadiumName.Length < 256 && string.IsNullOrEmpty(stadiumName));

                        do
                        {
                            Console.WriteLine("Stadionun saatliq qiymetini daxil edin:");
                            hourPriceStr = Console.ReadLine();
                        } while (!int.TryParse(hourPriceStr, out hourlyPrice));

                        do
                        {
                            Console.WriteLine("Stadionun tutumunu yazin:");
                            capacityStr = Console.ReadLine();
                        } while (!byte.TryParse(capacityStr, out capacity));

                        Stadium stadium = new Stadium
                        {
                            Name = stadiumName,
                            HourlyPrice = hourlyPrice,
                            Capacity = capacity,
                        };


                        stadiumData.AddStadium(stadium);
                        break;
                    case 2:

                        foreach (var item in stadiumData.GetAllStadiums())
                        {
                            Console.WriteLine($"{item.Id} - {item.Name} - {item.HourlyPrice} - {item.Capacity}");
                        };

                        break;
                    case 3:


                        do
                        {
                            Console.WriteLine("Id daxil edin:");
                            selectedIdStr = Console.ReadLine();
                        } while (!int.TryParse(selectedIdStr, out selectedId) && stadiumData.GetAllStadiums().Count < selectedId);

                        Console.WriteLine(stadiumData.GetStadiumById(selectedId).Name);

                        break;
                    case 4:


                        do
                        {
                            Console.WriteLine("Id daxil edin: ");
                            selectedIdStr = Console.ReadLine();
                        } while (!int.TryParse(selectedIdStr, out selectedId) && stadiumData.GetAllStadiums().Count < selectedId);

                        stadiumData.DeleteStadiumById(selectedId);

                        break;
                    case 5:
                        do
                        {
                            Console.WriteLine("User adini ve soyadini daxil edin:");
                            username = Console.ReadLine();
                        } while (username.Length < 256 && String.IsNullOrEmpty(username));

                        do
                        {
                            Console.WriteLine("User emailini daxil edin:");
                            email = Console.ReadLine();
                        } while (email.Length < 256 && String.IsNullOrEmpty(email));

                        User user = new User
                        {
                            FullName = username,
                            Email = email,
                        };


                        userData.AddUser(user);
                        break;
                    case 6:
                        foreach (var item in userData.GetAllUsers())
                        {
                            Console.WriteLine($"{item.Id} - {item.FullName} - {item.Email}");
                        };
                        break;
                    case 7:
                        foreach (var item in reservationData.GetAllReservations())
                        {
                            Console.WriteLine($"reservation id: {item.Id} - stadium id: {item.StadiumId} - user id: {item.UserId} - bashlangic tarixi: {item.StartDate} - bitme tarixi: {item.EndDate}");
                        };
                        break;
                    case 8:
                        Reservation reservations1 = new Reservation();
                        Console.WriteLine("\n============Users============\n");
                        foreach (var item in userData.GetAllUsers())
                        {
                            Console.WriteLine($"{item.Id} - {item.FullName} - {item.Email}");
                        };

                        do
                        {
                            Console.WriteLine("Id daxil edin:");
                            selectedIdStr = Console.ReadLine();
                        } while (!int.TryParse(selectedIdStr, out selectedId) && userData.GetAllUsers().Count < selectedId);
                        reservations1.UserId = selectedId;
                        Console.WriteLine("\n============Stadiums============\n");
                        foreach (var item in stadiumData.GetAllStadiums())
                        {
                            Console.WriteLine($"{item.Id} - {item.Name} - price: {item.HourlyPrice} - capacity: {item.Capacity}");
                        };

                        do
                        {
                            Console.WriteLine("Id daxil edin: ");
                            selectedIdStr = Console.ReadLine();
                        } while (!int.TryParse(selectedIdStr, out selectedId) && stadiumData.GetAllStadiums().Count < selectedId);
                        reservations1.StadiumId = selectedId;

                        do
                        {
                            Console.WriteLine("Rezervin bashlangic deyerini daxil edin:");
                            startStr = Console.ReadLine();
                        } while (DateTime.TryParse(startStr, out start));
                        reservations1.StartDate = start;

                        do
                        {
                            Console.WriteLine("Rezervin bitme deyerini daxil edin:");
                            endStr = Console.ReadLine();
                        } while (DateTime.TryParse(endStr, out end));
                        reservations1.EndDate = end;


                        reservationData.AddReservation(reservations1);
                        break;
                    case 9:
                        do
                        {
                            Console.WriteLine("Id daxil edin:");
                            selectedIdStr = Console.ReadLine();
                        } while (!int.TryParse(selectedIdStr, out selectedId) && reservationData.GetAllReservations().Count < selectedId);

                        Console.WriteLine("id: " + reservationData.GetReservationById(selectedId).Id + " - start date: " + reservationData.GetReservationById(selectedId).StartDate + " - end date: " + reservationData.GetReservationById(selectedId).EndDate);
                        break;
                    case 0:
                        check = false;
                        break;
                    default:
                        Console.WriteLine("Duzgun deyer daxil edin:");
                        break;
                }

            } while (check);
        }
    }
}
