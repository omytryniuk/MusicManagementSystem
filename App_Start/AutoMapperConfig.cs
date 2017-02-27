using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using AutoMapper;

namespace Assignment8
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            // Add map creation statements here
            // Mapper.CreateMap< FROM , TO >();

            // Disable AutoMapper v4.2.x warnings
#pragma warning disable CS0618

            // AutoMapper create map statements

            Mapper.CreateMap<Models.RegisterViewModel, Models.RegisterViewModelForm>();


            Mapper.CreateMap<Models.Artist, Controllers.ArtistBase>();
            Mapper.CreateMap<Controllers.ArtistAdd,Models.Artist>();
            Mapper.CreateMap<Models.Artist, Controllers.ArtistWithDetail>();



            Mapper.CreateMap<Models.Album, Controllers.AlbumBase>();
            Mapper.CreateMap<Controllers.AlbumAdd, Models.Album>();
            Mapper.CreateMap<Models.Album, Controllers.AlbumWithDetail>();
           
            Mapper.CreateMap<Models.Genre, Controllers.GenreBase>();

            Mapper.CreateMap<Models.Track, Controllers.TrackBase>();
            Mapper.CreateMap<Controllers.TrackAdd, Models.Track>();
            Mapper.CreateMap<Models.Track, Controllers.TrackWithDetail>();
            Mapper.CreateMap<Models.Track, Controllers.TrackClip>();
            // Add more below...

            Mapper.CreateMap<Models.MediaItem, Controllers.MediaItemBase>();
            Mapper.CreateMap<Models.MediaItem, Controllers.MediaItemContent>();
            Mapper.CreateMap<Models.Artist, Controllers.ArtistWithMediaInfo>();



#pragma warning restore CS0618
        }
    }
}