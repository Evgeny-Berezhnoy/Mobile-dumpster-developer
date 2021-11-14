using Models;

namespace Cars
{

    public class CarModel
    {

        #region Model

        private float _speed;
        private CarView _view;

        #endregion

        #region Properties

        public float Speed => _speed;
        public CarView View => _view;

        #endregion

        #region Constructors

        public CarModel(CarConfiguration configuration)
        {

            _speed  = configuration.Speed;
            _view   = ResourceLoader.LoadComponent<CarView>(configuration.View);

        }

        #endregion

    }

}