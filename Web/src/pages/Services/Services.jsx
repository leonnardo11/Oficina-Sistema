import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import axios from 'axios';

import '../../assets/styles/reset.css';
import '../../assets/styles/pages/services.css';

import Sidebar from '../../components/Sidebar';
import SidebarAdmin from '../../components/SidebarAdmin';

class Services extends Component {
  constructor(props) {
    super(props);
    this.state = {
      vehicleServices: [],
      vehicleData: {},
      userType: 2, // Defina o tipo de usuário (0 para administrador, 1 para funileiro, 2 para usuário comum)
    };
  }

  componentDidMount() {
    this.getVehicleServices();
    document.title = 'Serviços';
  }

  getVehicleServices = () => {
    const { id } = this.props.match.params;
    axios
      .get(`http://localhost:5000/api/Services/Budget/${id}`, {
        headers: {
          Authorization: 'Bearer ' + localStorage.getItem('user-token'),
        },
      })
      .then((response) => {
        if (response.status === 200) {
          const { data } = response;
          const vehicleServices = Array.isArray(data) ? data : [data];
          const vehicleData = vehicleServices[0]?.budget?.vehicle || {};
          this.setState({ vehicleServices, vehicleData });
          console.log('Lista de serviços: ', vehicleServices);
        }
      })
      .catch((error) => {
        console.log(error);
      });
  };

  formatBrazilianDate = (dateString) => {
    const date = new Date(dateString);
    return date.toLocaleDateString('pt-BR');
  };

  getServiceStatus = (status) => {
    switch (status) {
      case 0:
        return 'Finalizado';
      case 1:
        return 'Em andamento';
      case 2:
        return 'Pendente';
      default:
        return 'N/A';
    }
  };

  renderServiceCards = () => {
    const { vehicleServices } = this.state;

    if (!Array.isArray(vehicleServices) || vehicleServices.length === 0) {
      return <p className="no-services-message">Sem serviços disponíveis</p>;
    }

    return vehicleServices.map((service) => (
      <div className="services-content-background" key={service.id}>
        <div className="services-content-text">
          <p className="services-content-text-descricao">Descrição: {service.serviceDescription || 'N/A'}</p>
          <p>Tipo de Serviço: {service.serviceType?.typeName || 'N/A'}</p>
          <p>Data de Início: {this.formatBrazilianDate(service.creationDate) || 'N/A'}</p>
        </div>
        <div className="services-content-btn">
          <p>Status: {this.getServiceStatus(service.serviceStatus)}</p>
          <p className="services-content-btn-valor">Valor: R$ {service.price || '100.00'}</p>
        </div>
      </div>
    ));
  };

  render() {
    const { vehicleData, userType } = this.state;
    const { startDate, endDate } = this.props.location.state || {};

    return (
      <>
        {userType === 0 ? (
          <SidebarAdmin>
            {/* Renderizar conteúdo para administrador */}
            {/* ... */}
          </SidebarAdmin>
        ) : (
          <Sidebar>
            {/* Renderizar conteúdo para usuário comum */}
            <div className="services-header">
              <Link to="/home" className="services-header-back">{'< Chevrolet Onix'}</Link>
              <div className="services-title">
                <h1>Orçamento 07/06/2023</h1>
              </div>
              <div className="services-name">
                <p>{vehicleData.brandName} {vehicleData.modelName}</p>
              </div>
              <div className="services-texts">
                <p>Data de Término do Orçamento: {endDate || 'Ainda em execução'}</p>
              </div>
            </div>

            <div className="services-card-background">
              <p className="services-card-background-title">Serviços</p>

              <div className="services-card-content-background">
                {this.renderServiceCards()}
              </div>
            </div>
          </Sidebar>
        )}
      </>
    );
  }
}

export default Services;
