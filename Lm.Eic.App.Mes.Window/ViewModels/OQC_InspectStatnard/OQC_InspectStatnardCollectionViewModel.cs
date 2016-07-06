using System;
using System.Linq;
using DevExpress.Mvvm.POCO;
using Lm.Eic.App.Mes.Window.Common.Utils;
using Lm.Eic.App.Mes.Window.DbTwoMesDataModel;
using Lm.Eic.App.Mes.Window.Common.DataModel;
using Lm.Eic.App.Mes.Model;
using Lm.Eic.App.Mes.Window.Common.ViewModel;

namespace Lm.Eic.App.Mes.Window.ViewModels
{
    /// <summary>
    /// Represents the OQC_InspectStatnard collection view model.
    /// </summary>
    public partial class OQC_InspectStatnardCollectionViewModel : CollectionViewModel<OQC_InspectStatnard, decimal, IDbTwoMesUnitOfWork>
    {

        /// <summary>
        /// Creates a new instance of OQC_InspectStatnardCollectionViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static OQC_InspectStatnardCollectionViewModel Create(IUnitOfWorkFactory<IDbTwoMesUnitOfWork> unitOfWorkFactory = null)
        {
            return ViewModelSource.Create(() => new OQC_InspectStatnardCollectionViewModel(unitOfWorkFactory));
        }

        /// <summary>
        /// Initializes a new instance of the OQC_InspectStatnardCollectionViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the OQC_InspectStatnardCollectionViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected OQC_InspectStatnardCollectionViewModel(IUnitOfWorkFactory<IDbTwoMesUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.OQC_InspectStatnard)
        {
        }
    }
}