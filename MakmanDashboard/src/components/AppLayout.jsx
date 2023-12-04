import { Outlet } from 'react-router-dom';
import styled from 'styled-components';
import { Header } from './Header';

const Main = styled.main`
  display: flex;
  justify-content: center;
  height: 90%;
`;

const Layout = styled.div`
  height: 100dvh;
`;

export const AppLayout = () => {
  return (
    <Layout>
      {/* <Loader /> */}
      <Header />

      <Main>
        <Outlet />
      </Main>
    </Layout>
  );
};
