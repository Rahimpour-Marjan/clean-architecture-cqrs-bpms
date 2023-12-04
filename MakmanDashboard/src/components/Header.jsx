import { Link } from 'react-router-dom';
import styled from 'styled-components';
import { UserProfile } from './UserProfile';

const HeaderStyled = styled.header`
  display: flex;
  justify-content: space-around;
  align-items: center;
  padding: 1rem;
  background-color: var(--white);
  box-shadow: 0 2px 2px -2px gray;
  height: 5rem;
`;

const PostsLinkStyled = styled(Link)`
  color: var(--active-button);
  font-family: Roboto;
  font-size: 18px;
  font-weight: 700;
`;

export const Header = () => {
  return (
    <HeaderStyled>
      <PostsLinkStyled to='/posts'>Posts</PostsLinkStyled>

      <UserProfile />
    </HeaderStyled>
  );
};
