using DoulaServices.Data;
using DoulaServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoulaServices.Services
{
    public class DoulaService
    {
        private readonly Guid _userId;
        
        public DoulaService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateDoula(DoulaCreate model)
        {
            var entity =
                new Doula()
                {
                    OwnerId = _userId,
                    DoulaName = model.DoulaName,
                    DoulaLocation = model.DoulaLocation,
                    VbacExp = model.VbacExp,
                    AvailJan = model.AvailJan,
                    AvailFeb = model.AvailFeb,
                    AvailMar = model.AvailMar,
                    AvailApr = model.AvailApr,
                    AvailMay = model.AvailMay,
                    AvailJun = model.AvailJun,
                    AvailJul = model.AvailJul,
                    AvailAug = model.AvailAug,
                    AvailSep = model.AvailSep,
                    AvailOct = model.AvailOct,
                    AvailNov = model.AvailNov,
                    AvailDec = model.AvailDec
                };

            using (var ctx=new ApplicationDbContext())
            {
                ctx.Doulas.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<DoulaListItem> GetDoulas()
        {
            using (var ctx=new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Doulas
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                        e => new DoulaListItem
                        {
                            DoulaId = e.DoulaId,
                            DoulaName = e.DoulaName,
                            DoulaLocation = e.DoulaLocation,
                            VbacExp = e.VbacExp,
                            AvailJan = e.AvailJan,
                            AvailFeb = e.AvailFeb,
                            AvailMar = e.AvailMar,
                            AvailApr = e.AvailApr,
                            AvailMay = e.AvailMay,
                            AvailJun = e.AvailJun,
                            AvailJul = e.AvailJul,
                            AvailAug = e.AvailAug,
                            AvailSep = e.AvailSep,
                            AvailOct = e.AvailOct,
                            AvailNov = e.AvailNov,
                            AvailDec = e.AvailDec
                        }
                        );
                return query.ToArray();
            }
        }

        public DoulaDetail GetDoulaById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Doulas
                        .Single(e => e.DoulaId == id && e.OwnerId == _userId);
                return
                    new DoulaDetail
                    {
                        DoulaId = entity.DoulaId,
                        DoulaName = entity.DoulaName,
                        DoulaLocation = entity.DoulaLocation,
                        VbacExp = entity.VbacExp,
                        AvailJan = entity.AvailJan,
                        AvailFeb = entity.AvailFeb,
                        AvailMar = entity.AvailMar,
                        AvailApr = entity.AvailApr,
                        AvailMay = entity.AvailMay,
                        AvailJun = entity.AvailJun,
                        AvailJul = entity.AvailJul,
                        AvailAug = entity.AvailAug,
                        AvailSep = entity.AvailSep,
                        AvailOct = entity.AvailOct,
                        AvailNov = entity.AvailNov,
                        AvailDec = entity.AvailDec
                    };
            }
        }
        
        public bool UpdateDoula(DoulaEdit model)
        {
            using (var ctx=new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Doulas
                        .Single(e => e.DoulaId == model.DoulaId && e.OwnerId == _userId);

                entity.DoulaId = model.DoulaId;
                entity.DoulaName = model.DoulaName;
                entity.DoulaLocation = model.DoulaLocation;
                entity.AvailJan = model.AvailJan;
                entity.AvailFeb = model.AvailFeb;
                entity.AvailMar = model.AvailMar;
                entity.AvailApr = model.AvailApr;
                entity.AvailMay = model.AvailMay;
                entity.AvailJun = model.AvailJun;
                entity.AvailJul = model.AvailJul;
                entity.AvailAug = model.AvailAug;
                entity.AvailSep = model.AvailSep;
                entity.AvailOct = model.AvailOct;
                entity.AvailNov = model.AvailNov;
                entity.AvailDec = model.AvailDec;

                return ctx.SaveChanges()==1;
            }
        }

        public bool DeleteDoula(int doulaId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Doulas
                        .Single(e => e.DoulaId == doulaId && e.OwnerId == _userId);
                ctx.Doulas.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
