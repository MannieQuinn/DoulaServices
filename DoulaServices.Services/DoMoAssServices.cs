using DoulaServices.Data;
using DoulaServices.Models.DoMo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DoulaServices.Services
{
    public class DoMoAssServices
    {
        private readonly Guid _userId;

        public DoMoAssServices(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateDoMo(Create model)
        {
            var entity =
                new DoMo()
                {
                    OwnerId = _userId,
                    DoulaId = model.DoulaId,
                    MotherId = model.MotherId,
                    Notes = model.Notes
                };
            using (var ctx=new ApplicationDbContext())
            {
                ctx.DoMos.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ListItem> GetDoMos()
        {
            using (var ctx=new ApplicationDbContext())
            {
                var query =
                    ctx
                        .DoMos
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                        e => new ListItem
                        {
                            DoMoId = e.DoMoId,
                            DoulaId = e.DoulaId,
                            MotherId = e.MotherId,
                            Notes = e.Notes
                        });
                return query.ToArray();
            }
        }

        public Details GetDoMoById(int id)
        {
            using (var ctx=new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .DoMos
                        .Single(e => e.DoMoId == id && e.OwnerId == _userId);
                return
                    new Details
                    {
                        DoMoId = entity.DoMoId,
                        DoulaId = entity.DoulaId,
                        MotherId = entity.MotherId,
                        Notes = entity.Notes
                    };
            }
        }

        public bool UpdateDoMo(Edit model)
        {
            using (var ctx=new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .DoMos
                        .Single(e => e.DoMoId == model.DoMoId && e.OwnerId == _userId);

                entity.DoMoId = model.DoMoId;
                entity.DoulaId = model.DoulaId;
                entity.MotherId = model.MotherId;
                entity.Notes = model.Notes;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteDoMo(int doMoId)
        {
            using (var ctx=new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .DoMos
                        .Single(e => e.DoMoId == doMoId && e.OwnerId == _userId);
                ctx.DoMos.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
