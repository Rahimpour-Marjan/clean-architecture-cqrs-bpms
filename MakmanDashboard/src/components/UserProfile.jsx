import { Link } from 'react-router-dom';
import { styled } from 'styled-components';
import avatar from '../assets/avatar.png';

const UserProfileStyled = styled.div`
  display: flex;
  justify-content: center;
  align-items: center;
  gap: 1rem;

  .user-name {
    font-weight: 500;
  }
`;

const LogoutLinkStyled = styled(Link)`
  color: var(--active-button);
  font-weight: 500;
`;

export const UserProfile = () => {
  return (
    <UserProfileStyled>
      <img src={avatar} alt='user-avatar' height={70} width={70} />
      <div className='user-name'>Adele Fendi</div>
      <LogoutLinkStyled to='/login'>Logout</LogoutLinkStyled>
    </UserProfileStyled>
  );
};
