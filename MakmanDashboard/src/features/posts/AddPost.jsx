import { useNavigate } from 'react-router-dom';
import styled from 'styled-components';
import { Button } from '../../components';

const AddPostStyled = styled.div`
  display: flex;
  align-items: center;
  justify-content: space-between;
  gap: 1rem;
  margin: 2rem;
  max-width: 75rem;
`;

const P = styled.p`
  font-size: 36px;
  font-weight: 600;
`;

export const AddPost = () => {
  const navigate = useNavigate();

  return (
    <AddPostStyled>
      <P>All Posts</P>
      <Button
        variation='primary'
        onClick={() => {
          navigate('create');
        }}
      >
        + New post
      </Button>
    </AddPostStyled>
  );
};
