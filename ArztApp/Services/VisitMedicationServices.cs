using ArztApp.BAL;
using Microsoft.EntityFrameworkCore;

namespace ArztApp.Services
{
    public class VisitMedicationServices
    {
        #region Property
        private readonly ArztContext _appDBContext;
        #endregion

        #region Constructor
        public VisitMedicationServices(ArztContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        #endregion

        #region Get List of VisitMedication
        public async Task<List<VisitMedication>> GetAllAsync()
        {
            return await _appDBContext.VisitMedications.ToListAsync();
        }
        #endregion

        #region Insert VisitMedication
        public async Task<bool> InsertAsync(VisitMedication visitMedication)
        {
            await _appDBContext.VisitMedications.AddAsync(visitMedication);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Get VisitMedication by Id
        public async Task<VisitMedication> GetByIdAsync(int Id)
        {
            VisitMedication VisitMedication = await _appDBContext.VisitMedications.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return VisitMedication;
        }
        #endregion

        #region Update VisitMedication
        public async Task<bool> UpdateAsync(VisitMedication visitMedication)
        {
            _appDBContext.VisitMedications.Update(visitMedication);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Delete VisitMedication
        public async Task<bool> DeleteAsync(VisitMedication visitMedication)
        {
            _appDBContext.Remove(visitMedication);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        #endregion
    }
}
