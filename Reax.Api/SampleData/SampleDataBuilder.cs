
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Reax.Data.Entities;
using Reax.Data.Entities.Enums;

namespace Reax.Data.SampleData
{
    class SampleDataBuilder
    {
        public List<Movie> GetSampleData()
        {
            var fileDirectory = AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\" + @"SampleData\movies.json";
            
            var mediaData = new List<Movie>();
                using (var r = new StreamReader(fileDirectory))
                {
                    var json = r.ReadToEnd();

                    dynamic fileDeserializedObject = JsonConvert.DeserializeObject(json);
                    foreach (var line in fileDeserializedObject)
                    {
                        var content = line.content[0];
                        var currentMovie = new Movie()
                        {
                            MediaType = MediaTypes.Movie,
                            OriginalId = line._id,
                            Title = line.title,
                            Year = line.year,
                            Released = line.released,
                            Runtime = line.runtime,
                            Rated = line.rated,
                            Rating = line.rating,
                            Synopsis = line.synopsis,
                            ImdbId = line.imdbId,
                            CovertImage = line.covertImage,
                            FullImage = line.fullImage,
                            Trailer = line.trailer,
                            Actors = line.actors,
                            DateUpdate = Convert.ToDateTime(line.dateUpdate),
                            Categories = string.Join(", ", line.categories),
                            OnlyEnglish = line.onlyEnglish,
                            MonoAudio = line.monoAudio,
                            AudioSpanish = line.audioSpa,
                            AudioEnglish = line.audioEng,
                            Link = content.link,
                            Quality = content.quality,
                            HasOscar = line.hasOscar,
                            IsPremiere = line.isPremiere,
                            Genres = string.Join(", ",line.genres),
                            Views = line.view,
                            UserCreate = line.userCreate,
                            UserUpdate = line.userUpdate,
                            SubtitleSpanish = content.subtitleSpa,
                            SubtitleEnglish = content.subtitleEng,
                            SynopsisEnglish = line.synopsisEng,
                            MailOrigin = line.mailOrigin
                        };

                        mediaData.Add(currentMovie);
                        
                    }
                }

            

            return mediaData;

        }
    }
}

