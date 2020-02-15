import React from 'react';
import { Container } from 'react-bootstrap';
import Header from './../Header';
import HomeCarousel from './HomeCarousel';
import WelcomJumbotron from './WelcomJumbotron'
import Information from "./Information";
import WorkingInfo from './WorkingInfo'
import ImageCard from "./ImageCard";
import VideoCard from "./VideoCard";
import Footer from "./Footer";
const Home = (props) => {
    return (
        <Container fluid={true}>
            <HomeCarousel />
            <WelcomJumbotron />
            <Information />
            <WorkingInfo />
            <ImageCard />
            <VideoCard />
            <Footer/>
        </Container>
    )
}
export default Home