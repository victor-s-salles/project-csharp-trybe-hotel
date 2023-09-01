namespace TrybeHotel.Models;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TrybeHotel.Dto;

// 1. Implemente as models da aplicação
public class Room
{
    public int RoomId { get; set; }
    public string? Name { get; set; }
    public int Capacity { get; set; }
    public string? Image { get; set; }
    public int HotelId { get; set; }
    [ForeignKey("HotelId")]
    public Hotel? Hotel { get; set; }
    public IEnumerable<Booking>? Bookings { get; set; }



}