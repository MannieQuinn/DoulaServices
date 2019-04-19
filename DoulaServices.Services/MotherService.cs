using DoulaServices.Data;
using DoulaServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoulaServices.Services
{
    public class MotherService
    {
        private readonly Guid _userId;

        public MotherService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateMother(MotherCreate model)
        {
            var entity =
                new Mother()
                {
                    OwnerId = _userId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    MotherLocation = model.MotherLocation,
                    DateOfBirth = model.DateOfBirth,
                    DueDate = model.DueDate,
                    FirstPregnancy = model.FirstPregnancy,
                    VagBirAftCes = model.VagBirAftCes,
                    BreastFeeding = model.BreastFeeding
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Mothers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<MotherListItem> GetMothers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Mothers
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                        e => new MotherListItem
                        {
                            MotherId = e.MotherId,
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                            MotherLocation = e.MotherLocation,
                            DateOfBirth = e.DateOfBirth,
                            DueDate = e.DueDate,
                            FirstPregnancy = e.FirstPregnancy,
                            VagBirAftCes = e.VagBirAftCes,
                            BreastFeeding = e.BreastFeeding
                        }
                        );
                return query.ToArray();
            }
        }

        public MotherDetail GetMotherById(int id)
        {
            using (var ctx=new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Mothers
                        .Single(e => e.MotherId == id && e.OwnerId == _userId);
                return
                    new MotherDetail
                    {
                        MotherId = entity.MotherId,
                        FirstName = entity.FirstName,
                        LastName=entity.LastName,
                        MotherLocation = entity.MotherLocation,
                        DueDate = entity.DueDate,
                        FirstPregnancy = entity.FirstPregnancy,
                        VagBirAftCes = entity.VagBirAftCes,
                        BreastFeeding = entity.BreastFeeding
                    };
            }
        }

        public bool UpdateMother(MotherEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Mothers
                        .Single(e => e.MotherId == model.MotherId && e.OwnerId == _userId);

                entity.MotherId = model.MotherId;
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.MotherLocation = model.MotherLocation;
                entity.DueDate = model.DueDate;
                entity.BreastFeeding = model.BreastFeeding;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteMother(int motherId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Mothers
                        .Single(e => e.MotherId == motherId && e.OwnerId == _userId);
                ctx.Mothers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
