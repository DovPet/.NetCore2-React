import * as React from "react";
import { Route } from "react-router-dom";
import { Layout } from "./components/Layout";
import { Home } from "./components/Home";
import { FetchData } from "./components/FetchData";
import { Counter } from "./components/Counter";

import { Genres } from "./components/Genres";
import { GenreForm } from "./components/GenreForm";
import { GenreDetails } from "./components/GenreDetails";

import { Actors } from "./components/Actors";
import { ActorForm } from "./components/ActorForm";
import { ActorDetails } from "./components/ActorDetails";
export const routes = (
  <Layout>
    <Route exact path="/" component={Home} />
    <Route path="/counter" component={Counter} />
    <Route path="/fetchdata" component={FetchData} />

    <Route path="/genres" component={Genres} />
    <Route path="/genre/new" component={GenreForm} />
    <Route path="/genre/edit/:id" component={GenreForm} />
    <Route path="/genre/details/:id" component={GenreDetails} />

    <Route path="/actors" component={Actors} />
    <Route path="/actor/new" component={ActorForm} />
    <Route path="/actor/edit/:id" component={ActorForm} />
    <Route path="/actor/details/:id" component={ActorDetails} />
  </Layout>
);
