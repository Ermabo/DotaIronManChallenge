import 'bootstrap/dist/css/bootstrap.css';
import './Home.css';
import React, { Component } from 'react';
import { Col, Grid, Row } from 'react-bootstrap';


export class Home extends Component {
  displayName = Home.name


    constructor(props) {
        super(props);
        this.state = { itemBuild: [], hero: {}, loading: true };

        fetch('api/item/itembuild')
            .then(response => response.json())
            .then(data => {
                this.setState({ itemBuild: data });
            });

        fetch('api/hero/randomhero')
            .then(response => response.json())
            .then(data => {
                console.log("Hero data: ");
                console.log(data);

                this.setState({ hero: data, loading: false });
            });

    }

    static renderHeroChallenge(itemBuild, hero) {
        return (
            <Grid>
                <Row className='challenge-container'>
                    <Col className='challenge-row' sm={12}>
                        <div className="card">
                            <div className="card-body">
                                <h5 className="card-title">{hero.name}</h5>
                            </div>
                            <video className='card-video' width="256" height="256" autoPlay={true} loop={true} >
                                <source src={hero.videoUrl} type="video/webm" />
                            </video>
                            <div className='build'>
                                {itemBuild.map(item =>
                                    <div key={item.id} className='item'>
                                        <img src={item.imageUrl} className='item-image' alt="..." />
                                    </div>
                                )}
                                <script></script>

                            </div>
                        </div>
                    </Col>
                </Row>
            </Grid>
        );
    }

  render() {
      let contents = this.state.loading
          ? <p className='text-center'><em>Loading...</em></p>
          : Home.renderHeroChallenge(this.state.itemBuild, this.state.hero);

      return (
          <Col sm={12}>
              <h1 className='text-center'>DOTA2 Iron Man Challenge</h1>
              {contents}
          </Col>
    );
  }
}