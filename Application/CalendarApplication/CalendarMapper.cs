using Application.Calendar.Models;
using Application.Common;
using AutoMapper;

namespace Application.Calendar
{
    internal class CalendarMapper : Profile
    {
        public CalendarMapper()
        {
            DateTimeToPersianDateTimeConverter timeConverter = new DateTimeToPersianDateTimeConverter();
            CreateMap<Domain.Calendar, CalendarInfo>()
                  .ForMember(dto => dto.DateRecord, opt => opt.MapFrom(src =>
                    timeConverter.toShamsiDateTime(src.DateRecord)))
                  .ForMember(dto => dto.EventDate, opt => opt.MapFrom(src =>
                    timeConverter.toShamsiDateTime(DateTime.Parse(src.EventDate))))
                   .ForMember(dto => dto.NotificationDate, opt => opt.MapFrom(src =>
                    timeConverter.toShamsiDateTime(
                         (src.NotificationDate.Trim() == "" ? null : DateTime.Parse(src.NotificationDate)))))
                   .ForMember(dto => dto.EventTime, opt => opt.MapFrom(src => src.EventTime.Trim()))
                   .ForMember(dto => dto.NotificationTime, opt => opt.MapFrom(src => src.NotificationTime.Trim()));
        }
    }
}
